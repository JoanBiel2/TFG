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

    [SerializeField] private Transform player;
    [SerializeField] private InputActionReference cameramoveinput; // Para mover la camara con el stick derecho
    [SerializeField] private InputActionReference camerazoomin; // Hace el zoom con el d-pad del mando
    [SerializeField] private InputActionReference camerazoomout; // Hace el zoom con el d-pad del mando
    [SerializeField] private float controllerdragspeed;

    private enum ZoomDevice
    {
        None,
        Mouse,
        Gamepad
    }
    private ZoomDevice lastzoomdevice = ZoomDevice.None;


    private void Awake()
    {
        _maincam = Camera.main; //Setea la camara
    }

    public void OnDrag(InputAction.CallbackContext ctx)
    {
        if (ctx.started) _origin = GetMousePosition(); //Guarda la posición del mouse cada vez que damos al click derecho
        is_dragging = ctx.started || ctx.performed; //Será true si la acción a comenzado, o aun esta en curso
    }

    private void LateUpdate()
    {
        HandleZoom();

        if (is_dragging)
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
            float zoomspeed;

            if (lastzoomdevice == ZoomDevice.Gamepad)
            {
                zoomspeed = zoomspeedpad;
            }
            else
            {
                zoomspeed = zoomspeedmouse;
            }

            Vector3 pos = transform.position;
            pos.y -= zoominput * zoomspeed * Time.deltaTime;
            pos.y = Mathf.Clamp(pos.y, minzoom, maxzoom);
            transform.position = pos;
        }
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
