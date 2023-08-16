using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stepPuzzle : MonoBehaviour
{
    
    //private bool hasLost;
    
    public static int whiteStepNum;
    public static bool hasBlackStep;

    

    // Start is called before the first frame update
    void Start()
    {
        //hasLost = false;
        
        whiteStepNum = 0;
        hasBlackStep = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasBlackStep == true)
        {
            //hasLost = true;
            Debug.Log("Player has failed the Step Puzzle");
            Destroy(gameObject);
        }

        if (whiteStepNum == 10)
        {
            //hasSolved = true;
            Debug.Log("Player has solved the Step Puzzle");
            TreasureSpawner.hasSolved = true;
            //Destroy(gameObject);
            //Instantiate(treasureToSpawn, transform.position, transform.rotation);
            //enabled = false;


        }
    }


}
