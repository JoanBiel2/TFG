using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    [SerializeField] private GameObject menupanel;
    [SerializeField] private GameObject optionspanel;
    [SerializeField] private GameObject start;
    [SerializeField] private GameObject fullscreen;

    public void Awake()
    {
        EventSystem.current.SetSelectedGameObject(start);
    }
    public void NewGame()
    {
        DataManager.instance.NewGame();
        SceneManager.LoadScene("TestScene");
    }
    public void LoadGame()
    {
        DataManager.instance.ContinueGame();
        SceneManager.LoadScene("TestScene");
    }
    public void OpenOptions()
    {
        menupanel.SetActive(false);
        optionspanel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(fullscreen);
    }
    public void CloseOptions()
    {
        menupanel.SetActive(true);
        optionspanel.SetActive(false);
        EventSystem.current.SetSelectedGameObject(start);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
