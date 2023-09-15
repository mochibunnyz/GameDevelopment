using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSignTriggerStarter : MonoBehaviour
{
    public Canvas AreaSigns;

    void OnTriggerEnter(Collider OtherIn)
    {
        if (OtherIn.tag == "Player")
        {
            Debug.Log("The player entered trigger area");

            // Cancel any previous scheduled actions to ensure we don't have overlapping Invokes
            CancelInvoke("ShowCanvas");
            CancelInvoke("HideCanvas");

            // Schedule the showing of the canvas 1 second after the player enters
            Invoke("ShowCanvas", 1f);

            // Schedule the hiding of the canvas 6 seconds after the player enters 
            // (1 second for showing + 5 seconds for display time)
            Invoke("HideCanvas", 6f);
        }
    }

    void ShowCanvas()
    {
        AreaSigns.enabled = true;
    }

    void HideCanvas()
    {
        AreaSigns.enabled = false;
    }
}