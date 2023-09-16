using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] tutorialCanvases;
    private int currentIndex = 0;

    private void Start()
    {
        // Initially show the first canvas.
        ShowCanvas(currentIndex);
    }

    public void ShowNextCanvas()
    {
        if (currentIndex < tutorialCanvases.Length - 1)
        {
            currentIndex++;
            ShowCanvas(currentIndex);
        }
    }

    public void ShowPreviousCanvas()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            ShowCanvas(currentIndex);
        }
    }

    private void ShowCanvas(int index)
    {
        // Pause the game when a tutorial canvas is shown
        Time.timeScale = 0;

        for (int i = 0; i < tutorialCanvases.Length; i++)
        {
            tutorialCanvases[i].SetActive(i == index);
        }
    }

    // Function to close the tutorial
    public void CloseTutorial()
    {
        foreach (GameObject canvas in tutorialCanvases)
        {
            canvas.SetActive(false);
        }
    
        // Only resume the game if it's not paused
        if (!PauseMenuController.isPaused)
        {
            Time.timeScale = 1;
        }
}

    // New method to open the first tutorial canvas
    public void OpenFirstCanvas()
    {
        currentIndex = 0;  // Reset to the first canvas
        ShowCanvas(currentIndex);
    }
}
