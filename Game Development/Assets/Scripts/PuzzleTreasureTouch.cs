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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
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
