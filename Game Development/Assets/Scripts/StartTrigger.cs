using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTrigger : MonoBehaviour
{
    public Canvas promptCanvas; // Drag your 'Press E' canvas here in the Inspector
    public GameObject barrier;  // Drag the barrier GameObject here in the Inspector
    private bool playerNear = false;

    void Update()
    {
        if (playerNear && Input.GetKeyDown(KeyCode.E))
        {
            GameController.Instance.gameStarted = true;
            promptCanvas.enabled = false;  // Hide the prompt
            barrier.SetActive(false);  // Disable the barrier
            // gameObject.SetActive(false);  // This line is commented out to keep the starting object visible
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = true;
            if (!GameController.Instance.gameStarted)
            {
                promptCanvas.enabled = true;  // Show the prompt
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = false;
            promptCanvas.enabled = false;  // Hide the prompt
        }
    }
}