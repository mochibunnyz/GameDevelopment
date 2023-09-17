using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractHint : MonoBehaviour
{
    public Canvas PressE;
    public Canvas InfoCanvas; // Renamed for clarity

    private void OnTriggerEnter(Collider EntityEnter)
    {
        // Check if it's the player
        if(EntityEnter.tag == "Player")
        {
            Debug.Log("The player entered trigger area");
            PressE.enabled = true;
        }
    }

    private void OnTriggerExit(Collider EntityExit)
    {
        if(EntityExit.tag == "Player")
        {
            PressE.enabled = false;
            InfoCanvas.enabled = false;
        }
    }

    private void OnTriggerStay(Collider EntityIn)
    {
        if(EntityIn.tag == "Player")
        {
            if(Input.GetKey(KeyCode.E))
            {
                Debug.Log("The player pressed E");
                InfoCanvas.enabled = true;
                PressE.enabled = false;
            }

            if(Input.GetKey(KeyCode.Escape))
            {
                EscapeCanvas();
            }
        }
    }

    public void EscapeCanvas()
    {
        Debug.Log("Player pressed escape");
        InfoCanvas.enabled = false;
        PressE.enabled = true;
    }
}