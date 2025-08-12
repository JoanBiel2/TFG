using NUnit.Framework.Constraints;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private PlayerControls playercon;
    private InputAction menu;

    [SerializeField] private PlayerInput pi;

    [SerializeField]private InventoryManager inv;

    [SerializeField] private GameObject pauseui;
    [SerializeField] private GameObject optionsui;
    private bool ispaused;

    [SerializeField] private GameObject mainmenufirst; //Para el menu principal. Es un botón
    [SerializeField] private GameObject settingsmenufirst; //Para el menu de opciones

    private Dialogue dialogue;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        dialogue = GameObject.Find("DialogueManager").GetComponent<Dialogue>();
        playercon = new PlayerControls();
    }

    private void OnEnable()
    {
        menu = playercon.UI.Pause;
        menu.Enable();

        menu.performed += Pause; //No se porque el +=, pero hace que se dispare el evento

    }

    private void OnDisable()
    {
        menu.Disable();
    }

    public bool IsPaused()
    {
        return ispaused;
    }
    void Pause(InputAction.CallbackContext ctx)
    {
        if (!inv.IsActive())
        {
            ispaused = !ispaused;
            if (ispaused)
            {
                ActivateMenu();
                pi.SwitchCurrentActionMap("UI");
            }
            else
            {
                DeactivateMenu();
                if (dialogue.IsActive())
                {
                    pi.SwitchCurrentActionMap("DialogueControl");
                }

                else
                {
                    pi.SwitchCurrentActionMap("Player");
                }
            }
        }
    }

    void ActivateMenu()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        pauseui.SetActive(true);

        EventSystem.current.SetSelectedGameObject(mainmenufirst); //El propio eventsystem se ocupa del movimiento por el menu.

        CanvasGroup canvasgroup = dialogue.dialoguepanel.GetComponentInParent<CanvasGroup>(); //Sirve para que desde el menu, el jugador no pueda acceder a las opciones
        canvasgroup.interactable = false;
        canvasgroup.blocksRaycasts = false;
    }

    public void DeactivateMenu()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        pauseui.SetActive(false);
        optionsui.SetActive(false);
        ispaused = false;

        StartCoroutine(dialogue.SelectedFirstChoice());

        CanvasGroup canvasgroup = dialogue.dialoguepanel.GetComponentInParent<CanvasGroup>(); //Sirve para que desde el menu, el jugador no pueda acceder a las opciones
        canvasgroup.interactable = true;
        canvasgroup.blocksRaycasts = true;
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
        AudioListener.pause = false;
        Time.timeScale = 1;
    }

    public void OpenOptions()
    {
        pauseui.SetActive(false);
        optionsui.SetActive(true);
        EventSystem.current.SetSelectedGameObject(settingsmenufirst);
    }

    public void ReturnMenu()
    {
        pauseui.SetActive(true);
        optionsui.SetActive(false);
    }
}
