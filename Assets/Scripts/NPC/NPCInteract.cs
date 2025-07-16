using UnityEngine;
using UnityEngine.InputSystem;

public class NPCInteract : MonoBehaviour
{
    private PlayerInput pi;
    private bool playernear = false;

    public string[] lines;

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
                dialogueManager.StartDialogueFromNPC(lines);
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
