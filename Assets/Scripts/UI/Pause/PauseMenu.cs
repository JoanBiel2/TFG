using NUnit.Framework.Constraints;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    private PlayerControls playercon;
    private InputAction menu;

    [SerializeField] private GameObject PauseUI;
    private bool IsPaused;

    [SerializeField] private GameObject mainmenufirst; //Para el menu principal
    [SerializeField] private GameObject settingsmenufirst; //Para el menu de opciones

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
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

    void Pause(InputAction.CallbackContext ctx)
    {
        IsPaused = !IsPaused;

        if (IsPaused)
        {
            ActivateMenu();
        }
        else
        {
            DeactivateMenu();
        }
    }
    void ActivateMenu()
    {
        Time.timeScale = 0;
        AudioListener.pause = true; //Quizas lo mantengo, o puedo bajar el volumen
        PauseUI.SetActive(true);

        EventSystem.current.SetSelectedGameObject(mainmenufirst); //El propio eventsystem se ocupa del movimiento por el menu.
    }

    public void DeactivateMenu()
    {
        Time.timeScale = 1;
        AudioListener.pause = false; //Quizas lo mantengo, o puedo bajar el volumen
        PauseUI.SetActive(false);
        IsPaused = false;

        EventSystem.current.SetSelectedGameObject(null);
    }
}
