using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3TreasureTouch : MonoBehaviour
{
    public GameObject treasuretouch;
    public RingPuzzleController puzzleController; // Reference to the RingPuzzleController script.
    public GameObject treasurePanel; // Reference to the UI Panel you created.

    private bool isActivated = false;

    void Start()
    {
        treasuretouch.SetActive(false);
        treasurePanel.SetActive(false); // Hide the panel initially.
        gameObject.SetActive(false); // Hide the chest initially
    }

    void Update()
    {
        if (puzzleController.PuzzleSolved)
        {
            // Make the chest appear (set it active)
            treasuretouch.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check both conditions: if it's the player and if the puzzle has been solved.
        if (other.tag == "Player" && puzzleController.PuzzleSolved)
        {
            SimpleSampleCharacterControl.numberOfTreasures += 1;
            Debug.Log("Treasures Obtained:" + SimpleSampleCharacterControl.numberOfTreasures);

            // Show the panel if not already activated
            if (!isActivated)
            {
                isActivated = true;
                ActivatePanelForDuration();
            }

            // Destroy the treasure chest
            Destroy(gameObject);
        }
    }

    private void ActivatePanelForDuration()
    {
        treasurePanel.SetActive(true);

        // Start a coroutine to hide the panel after 5 seconds
        StartCoroutine(HidePanelAfterDelay(5f));
    }

    private IEnumerator HidePanelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        treasurePanel.SetActive(false);
        isActivated = false;
    }
}


