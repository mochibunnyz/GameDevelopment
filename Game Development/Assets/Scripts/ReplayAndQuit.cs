using UnityEngine.SceneManagement;
using UnityEngine;

public class ReplayAndQuit : MonoBehaviour
{
    public string gameSceneName = "Main Scene";
    public string mainMenuSceneName = "MainMenu";

    // This method is called when the object becomes enabled and active
    private void OnEnable()
    {
        Time.timeScale = 0; // Pause the game
    }

    public void ReplayGame()
    {
        Time.timeScale = 1; // Unpause the game
        StartCoroutine(LoadGameSceneAsync());
    }

    public void QuitGame()
    {
        Time.timeScale = 1; // Unpause the game
        StartCoroutine(LoadMainMenuAsync());
    }

    IEnumerator LoadGameSceneAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(gameSceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    IEnumerator LoadMainMenuAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(mainMenuSceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Now the main menu is loaded, so we can access its components
        FindObjectOfType<MenuController>().ReinitializeMenu();
    }
}