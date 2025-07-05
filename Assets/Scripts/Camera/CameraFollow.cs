using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{
    private Vector3 _origin;
    private Vector3 _diff;

    private Camera _maincam;

    private bool is_dragging;
    private float dragSpeed = 3f;

    private float zoomSpeed = 150f;
    private float minZoom = 10f;
    private float maxZoom = 20f;
    private float maxdist = 30f;

    [SerializeField] private Transform player;

    private void Awake()
    {
        _maincam = Camera.main; //Setea la camara
    }

    public void OnDrag(InputAction.CallbackContext ctx)
    {
        if (ctx.started) _origin = GetMousePosition(); //Guarda la posició del mouse cada vegada que donem al click dret
        is_dragging = ctx.started || ctx.performed; //Serà true si l'acció a començat, o encara esta en curs
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

        ClampDistanceToPlayer();
    }

    private void HandleZoom()
    {
        float scroll = Mouse.current.scroll.ReadValue().y;

        if (scroll != 0f)
        {
            Vector3 pos = transform.position;
            pos.y -= scroll * zoomSpeed * Time.deltaTime;
            pos.y = Mathf.Clamp(pos.y, minZoom, maxZoom);
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
