using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTreasureTouch : MonoBehaviour
{
    public GameObject treasuretouch;
    public bool hasBlackStep;
    

    // Start is called before the first frame update
    void Start()
    {
        treasuretouch.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (stepPuzzle.hasBlackStep == true)
        {
            
            Debug.Log("Puzzle Treasure Destroyed");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            CharacterControl.numberOfTreasures += 1;
            Debug.Log("Treasures Obtained:" + CharacterControl.numberOfTreasures);
            Destroy(gameObject);
            
            treasureTouch();

        }
    }

    void treasureTouch()
    {
        treasuretouch.SetActive(true);
    }

}
