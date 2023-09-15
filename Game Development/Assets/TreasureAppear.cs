using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureAppear : MonoBehaviour
{

public GameObject treasureChest;
public buttonpad buttonPad;


    // Start is called before the first frame update

    void Start()
    {
        treasureChest.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            SimpleSampleCharacterControl.numberOfTreasures += 1;
            Debug.Log("Treasures Obtained:" + SimpleSampleCharacterControl.numberOfTreasures);
            Destroy(gameObject);
            
            treasureAppear();
        }
    }

    void treasureAppear()
    {
        treasureChest.SetActive(true);
    }
}
