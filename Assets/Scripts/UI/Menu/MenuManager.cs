using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    [SerializeField] private GameObject menupanel;
    [SerializeField] private GameObject optionspanel;

    public void ChangeScene()
    {
        SceneManager.LoadScene("TestScene");
    }
    public void OpenOptions()
    {
        menupanel.SetActive(false);
        optionspanel.SetActive(true);
    }
    public void CloseOptions()
    {
        menupanel.SetActive(true);
        optionspanel.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
