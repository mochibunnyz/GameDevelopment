using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseMenuPanel;
    public TutorialManager tutorialManager; // Directly reference the TutorialManager script
    public static bool isPaused = false;  // This is a static variable

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
        pauseMenuPanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        pauseMenuPanel.SetActive(false);
    }

    public void OpenTutorial()
    {
        tutorialManager.OpenFirstCanvas();
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1;
        StartCoroutine(LoadMainMenu());
    }

    IEnumerator LoadMainMenu()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Additive);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Now the main menu is loaded, so we can access its components
        FindObjectOfType<MenuController>().ReinitializeMenu();

        // Optionally, unload the game scene if you no longer need it
        SceneManager.UnloadSceneAsync("Main Scene");
    }
}