using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class CameraFollow : MonoBehaviour
{
    private Vector3 _origin;
    private Vector3 _diff;

    private Camera _maincam;

    private bool is_dragging;
    private float dragSpeed = 3f;

    private float zoomspeedpad = 20;
    private float zoomspeedmouse = 150;
    private float minzoom = 10f;
    private float maxzoom = 20f;
    private float maxdist = 30f;
    private float minZoomZ = -4f;
    private float maxZoomZ = -12f;
    private bool zoomAffectsZ;

    private float targetZoom;
    private bool followPlayer = false;

    [SerializeField] private Transform player;
    [SerializeField] private InputActionReference cameramoveinput; // Para mover la camara con el stick derecho
    [SerializeField] private InputActionReference camerazoomin; // Hace el zoom con el d-pad del mando
    [SerializeField] private InputActionReference camerazoomout; // Hace el zoom con el d-pad del mando
    [SerializeField] private InputActionReference followPlayerAction;
    [SerializeField] private float controllerdragspeed;

    private Vector3 followOffset;

    private enum ZoomDevice
    {
        None,
        Mouse,
        Gamepad
    }
    private ZoomDevice lastzoomdevice = ZoomDevice.None;

    private void Start()
    {
        followOffset = transform.position - player.position;
        targetZoom = transform.position.y;
    }
    private void Awake()
    {
        _maincam = Camera.main; //Setea la camara
    }

    private void Update()
    {
        if (followPlayerAction.action.WasPressedThisFrame())
        {
            followPlayer = !followPlayer;
        }
    }

    public void OnToggleFollow(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            followPlayer = !followPlayer;
        }
    }

    public void FixedCamera()
    {
        Vector3 targetPos = transform.position;
        zoomAffectsZ = followPlayer;

        targetPos.x = player.position.x + followOffset.x;
        if (followPlayer)
        {
            targetPos.z = player.position.z+ 5f + followOffset.z;
        }
        else
        {
            targetPos.z = player.position.z + followOffset.z;
        }

        // Mantiene la altura actual
        targetPos.y = transform.position.y;

        transform.position = Vector3.Lerp(
            transform.position,
            targetPos,
            Time.deltaTime * 5f
        );
    }

    public void OnDrag(InputAction.CallbackContext ctx)
    {
        if (ctx.started) _origin = GetMousePosition(); //Guarda la posición del mouse cada vez que damos al click derecho
        is_dragging = ctx.started || ctx.performed; //Será true si la acción a comenzado, o aun esta en curso
    }

    private void LateUpdate()
    {
        HandleZoom();

        if (followPlayer)
        {
            FixedCamera();
        }
        else if (is_dragging)
        {
            _diff = GetMousePosition() - transform.position;
            Vector3 targetPos = _origin - _diff;
            targetPos.y = transform.position.y;
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * dragSpeed);
        }
        else
        {
            HandleControlDrag();
        }

        ClampDistanceToPlayer();
    }
    private void HandleControlDrag() //Se encarga del movimiento de la camara del mando
    {
        Vector2 input = cameramoveinput.action.ReadValue<Vector2>();

        if (input.sqrMagnitude > 0.01f)
        {
            Vector3 move = new Vector3(input.x, 0, input.y);
            transform.position += move * controllerdragspeed * Time.deltaTime;
        }
    }

    public void DisableCameraActions()
    {
        cameramoveinput?.action.Disable();
        camerazoomin?.action.Disable();
        camerazoomout?.action.Disable();
    }

    public void EnableCameraActions()
    {
        cameramoveinput?.action.Enable();
        camerazoomin?.action.Enable();
        camerazoomout?.action.Enable();
    }

    private void HandleZoom()
    {
        float scroll = Mouse.current.scroll.ReadValue().y;
        float zoomin = camerazoomin.action.ReadValue<float>();
        float zoomout = camerazoomout.action.ReadValue<float>();

        float controllerzoom = zoomin - zoomout;
        float zoominput = scroll + controllerzoom;

        // Detectar último dispositivo usado
        if (Mathf.Abs(scroll) > 0.01f)
        {
            lastzoomdevice = ZoomDevice.Mouse;
        }
        else if (Mathf.Abs(controllerzoom) > 0.01f)
        {
            lastzoomdevice = ZoomDevice.Gamepad;
        }
        // Zona muerta
        if (Mathf.Abs(zoominput) > 0.01f)
        {
            float zoomspeed = lastzoomdevice == ZoomDevice.Gamepad
                ? zoomspeedpad
                : zoomspeedmouse;

            targetZoom -= zoominput * zoomspeed;
            targetZoom = Mathf.Clamp(targetZoom, minzoom, maxzoom);
        }

        Vector3 pos = transform.position;

        // Zoom vertical
        pos.y = Mathf.Lerp(pos.y, targetZoom, 10f * Time.deltaTime);

        // Zoom en Z solo cuando sigue al jugador
        if (zoomAffectsZ)
        {
            float zoomT = Mathf.InverseLerp(minzoom, maxzoom, targetZoom);

            float targetZOffset = Mathf.Lerp(minZoomZ, maxZoomZ, zoomT);

            pos.z = Mathf.Lerp(
                pos.z,
                player.position.z + targetZOffset,
                10f * Time.deltaTime
            );
        }

        transform.position = pos;
    }

    private void ClampDistanceToPlayer()
    {
        if (player == null) return;

        Vector3 offset = transform.position - player.position;

        // Limitar X y Z individualmente
        float clampedX = Mathf.Clamp(offset.x, -maxdist, maxdist); //Ajustar mucho
        float clampedZ = Mathf.Clamp(offset.z, -70, 50); //Ajustar mucho

        Vector3 clampedOffset = new Vector3(clampedX, 0, clampedZ);

        transform.position = player.position + clampedOffset + Vector3.up * (transform.position.y - player.position.y);
    }


    private Vector3 GetMousePosition()
    {
        Vector3 MousePos = Mouse.current.position.ReadValue();
        MousePos.z = 24;
        return _maincam.ScreenToWorldPoint(MousePos);
    }
}
