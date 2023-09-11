using UnityEngine.SceneManagement;
using UnityEngine;

public class ReplayAndQuit : MonoBehaviour
{
    public void ReplayGame()
    {
        SceneManager.LoadScene("Main Scene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
