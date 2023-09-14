using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaVicinity : MonoBehaviour
{
    public Canvas AreaSigns;

    void OnTriggerEnter(Collider OtherIn)
    {
        if (OtherIn.tag == "Player")
        {
            Debug.Log("The player entered trigger area");
            // Shows the press E prompt
            AreaSigns.enabled = true;

            // Cancel any previous scheduled hide actions to ensure we don't have overlapping Invokes
            CancelInvoke("HideCanvas");
            // Schedule the hiding of the canvas
            Invoke("HideCanvas", 5f);
        }
    }

    void HideCanvas()
    {
        AreaSigns.enabled = false;
    }
}