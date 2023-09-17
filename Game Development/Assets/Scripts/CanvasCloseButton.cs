using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasCloseButton : MonoBehaviour
{
    public Canvas canvasToClose;  // Reference to the canvas you want to close

    public void CloseCanvas()
    {
        if (canvasToClose != null)
        {
            canvasToClose.enabled = false;
        }
        else
        {
            Debug.LogError("Canvas reference not set in the CloseCanvasButton script.");
        }
    }
}
