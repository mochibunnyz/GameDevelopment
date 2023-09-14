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
    }
}