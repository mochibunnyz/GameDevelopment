using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle5TreasureTouch : MonoBehaviour
{
    public GameObject treasuretouch;
    public buttonpad buttonPuzzle;  // Reference to the button puzzle controller.

    void Start()
    {
        gameObject.SetActive(false); // Hide the chest initially
        treasuretouch.SetActive(false);
    }

    void Update()
    {
        if (buttonPuzzle.PuzzleSolved)
        {
            // Make the chest appear (set it active)
            treasuretouch.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check both conditions: if it's the player and if the puzzle has been solved.
        if (other.tag == "Player" && buttonPuzzle.PuzzleSolved)
        {
            SimpleSampleCharacterControl.numberOfTreasures += 1;
            Debug.Log("Treasures Obtained: " + SimpleSampleCharacterControl.numberOfTreasures);
            Destroy(gameObject);
            treasureTouch();
        }
    }

    void treasureTouch()
    {
        treasuretouch.SetActive(true);
    }
}