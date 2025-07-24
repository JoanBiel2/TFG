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

    [SerializeField] private GameObject pauseui;
    [SerializeField] private GameObject optionsui;
    private bool ispaused;

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
        ispaused = !ispaused;

        if (ispaused)
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
        AudioListener.pause = true;
        pauseui.SetActive(true);

        EventSystem.current.SetSelectedGameObject(mainmenufirst); //El propio eventsystem se ocupa del movimiento por el menu.
    }

    public void DeactivateMenu()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        pauseui.SetActive(false);
        optionsui.SetActive(false);
        ispaused = false;

        EventSystem.current.SetSelectedGameObject(null);
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
    }

    public void ReturnMenu()
    {
        pauseui.SetActive(true);
        optionsui.SetActive(false);
    }
}
