using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureTouch : MonoBehaviour
{
    public GameObject treasuretouch;
    // Start is called before the first frame update
    void Start()
    {
        treasuretouch.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
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
