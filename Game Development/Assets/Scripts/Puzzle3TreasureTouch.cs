using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3TreasureTouch : MonoBehaviour
{
    public GameObject treasuretouch;
    public RingPuzzleController puzzleController;  // Reference to the RingPuzzleController script.

    void Start()
    {
        gameObject.SetActive(false); // Hide the chest initially
        treasuretouch.SetActive(false);
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
            Destroy(gameObject);
            
            treasureTouch();
        }
    }

    void treasureTouch()
    {
        treasuretouch.SetActive(true);
    }
}