using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controls : MonoBehaviour
{
    public GameObject ControlsText; // This is the GameObject with your textbox
    private bool isPlayerInside = false;

    private void OnTriggerEnter(Collider other)
    {
        // You can also use tags or any other method to identify the player.
        if (other.gameObject.name == "Player") 
        {
            ControlsText.SetActive(true);
            isPlayerInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            ControlsText.SetActive(false);
            isPlayerInside = false;
        }
    }

}