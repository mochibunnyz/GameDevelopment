using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseMenuPanel;
    public GameObject tutorialManager; // Drag your TutorialManager GameObject here
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
        // Call OpenFirstCanvas instead of ShowTutorial
        tutorialManager.GetComponent<TutorialManager>().OpenFirstCanvas();
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1;
        // Load the main menu scene. Replace "MainMenuScene" with the name of your main menu scene.
        SceneManager.LoadScene("MainMenu");
    }
}