using UnityEngine;
using UnityEngine.SceneManagement;

public class BootGame : MonoBehaviour
{
    private void Start()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
