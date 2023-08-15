using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component for the object
    public float interactionRange = 3.0f; // The range within which the player can interact with objects

    private void Update()
    {
        // Check for player input (e.g., pressing a button) to interact
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Cast a ray from the camera forward to detect interactable objects
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, interactionRange))
            {
                // Check if the raycast hit an object with this script attached
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    // Interact with the object
                    interactable.Interact();
                }
            }
        }
    }

    public virtual void Interact()
    {
        // Play the interact animation if available
        if (animator != null)
        {
            animator.SetTrigger("Interact");
        }

        // Add custom interaction behavior here (if needed)
        Debug.Log("Interacting with " + gameObject.name);
    }
}