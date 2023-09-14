using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsText : MonoBehaviour
{
    public Canvas Controls;

    // Array of tutorial canvases
    public Canvas[] tutorialCanvases;

    void OnTriggerEnter(Collider OtherIn)
    {
        if (OtherIn.tag == "Player" && !AnyTutorialCanvasActive())
        {
            Debug.Log("The player entered trigger area");
            Controls.enabled = true;
        }
    }

    void OnTriggerExit(Collider OtherOut)
    {
        if (OtherOut.tag == "Player")
        {
            Controls.enabled = false;
        }
    }

    bool AnyTutorialCanvasActive()
    {
        // Iterate through each tutorial canvas to see if any are enabled.
        foreach (Canvas canvas in tutorialCanvases)
        {
            if (canvas.enabled)
            {
                return true;  // A tutorial canvas is active
            }
        }
        return false;  // None of the tutorial canvases are active
    }
}