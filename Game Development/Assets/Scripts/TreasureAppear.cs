using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureAppear : MonoBehaviour
{

public GameObject treasuretouch;
public GameObject treasureChest;
public buttonpad puzzleController;

    // Start is called before the first frame update

    void Start()
    {
        treasureChest.SetActive(false);
        treasuretouch.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(puzzleController.PuzzleSolved)
        {
            treasuretouch.SetActive(true);
        }       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && puzzleController.PuzzleSolved)
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
