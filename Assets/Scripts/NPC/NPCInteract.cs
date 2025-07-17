using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class NPCInteract : MonoBehaviour
{
    private PlayerInput pi;
    private bool playernear = false;

    public DialogueLine[] dialogueLines; //Nombre y linea de dialogo (de momento)

    [SerializeField] private Dialogue dialogueManager;

    [SerializeField] private Renderer prompt; // Renderer del objeto visual
    [SerializeField] private Material keyboardMaterial;
    [SerializeField] private Material gamepadMaterial;

    private System.IDisposable listener;
    void Start()
    {
        pi = GameObject.Find("Player").GetComponentInChildren<PlayerInput>();
        prompt.gameObject.SetActive(false);
        prompt.transform.localPosition = new Vector3(0, 2.5f, 0);
    }

    void Update()
    {
        if (playernear && pi.actions["Interact"].IsPressed())
        {
            if (dialogueManager != null)
            {
                dialogueManager.StartDialogueFromNPC(dialogueLines);
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            playernear = true;
            prompt.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            playernear = false;
            prompt.gameObject.SetActive(false);
        }
    }
    private void OnEnable()
    {
        listener = InputSystem.onAnyButtonPress.Call(OnAnyInput);
    }

    private void OnDisable()
    {
        listener?.Dispose();
    }
    void OnAnyInput(InputControl control)
    {
        var device = control.device;
        if (device is Gamepad)
        {
            prompt.material = gamepadMaterial;
        }
        else if (device is Keyboard || device is Mouse)
        {
            prompt.material = keyboardMaterial;
        }
    }
}
