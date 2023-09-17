using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvisiblePrompt : MonoBehaviour
{
    public GameObject promptCanvas; // Reference to the Canvas GameObject
    public float displayTime = 3f; // How long to display the prompt in seconds

    private bool isDisplayingPrompt = false;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected"); // Debugging message
        // Check if the player hits the invisible object
        if (isDisplayingPrompt == false && collision.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            // Player hit the invisible object, so display the prompt
            promptCanvas.SetActive(true);
            isDisplayingPrompt = true;
            Invoke("HidePrompt", displayTime);
        }
    }

    private void HidePrompt()
    {
        promptCanvas.SetActive(false);
        isDisplayingPrompt = false;
    }
}