using UnityEngine;
using UnityEngine.InputSystem;

public class NPCInteract : MonoBehaviour
{
    private PlayerInput pi;
    private bool playernear = false;

    public DialogueLine[] dialogueLines; //Nombre y linea de dialogo (de momento)

    [SerializeField] private Dialogue dialogueManager;
    void Start()
    {
        pi = GameObject.Find("Player").GetComponentInChildren<PlayerInput>();
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
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            playernear = false;
        }
    }
}
