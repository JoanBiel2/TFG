using NUnit.Framework.Constraints;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    private PlayerControls playercon;
    private InputAction menu;

    [SerializeField] private GameObject PauseUI;
    [SerializeField] private bool IsPaused;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playercon = new PlayerControls();
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }

    public void DeactivateMenu()
    {
        Time.timeScale = 1;
        AudioListener.pause = false; //Quizas lo mantengo, o puedo bajar el volumen
        PauseUI.SetActive(false);
        IsPaused = false;
    }
}
