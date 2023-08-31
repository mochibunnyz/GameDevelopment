using UnityEngine.SceneManagement;
using UnityEngine;

public class ReplayAndQuit : MonoBehaviour
{
    public void ReplayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
