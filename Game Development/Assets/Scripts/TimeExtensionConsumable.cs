using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeExtensionConsumable : MonoBehaviour
{
    public float timeToAdd = 30.0f; // Amount of time to add in seconds

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Check if the colliding object is the player
            GameController.Instance.ExtendTime(timeToAdd); // Call a method in the GameController to extend the time
            Destroy(gameObject); // Destroy the consumable object
        }
    }
}
