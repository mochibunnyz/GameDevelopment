using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treasureAppear : MonoBehaviour
{

public GameObject treasure5;
public buttonpad buttonPad;


    // Start is called before the first frame update

    void Start()
    {
        gameObject.SetActive(false);
        treasure5.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(buttonPad.puzzleSolved)
        {
            treasure5.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && PuzzleSolved)
        {
            SimpleSampleCharacterControl.numberOfTreasures += 1;
            Debug.Log("Treasures Obtained:" + SimpleSampleCharacterControl.numberOfTreasures);
            Destroy(gameObject);
            
            treasure5();
        }
    }

    void Treasure5()
    {
        treasure5.SetActive(true);
    }
}
