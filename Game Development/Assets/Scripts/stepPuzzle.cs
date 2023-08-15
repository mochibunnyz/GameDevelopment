using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stepPuzzle : MonoBehaviour
{
    //private bool hasSolved;
    //private bool hasLost;
    LightUpStep step;

    // Start is called before the first frame update
    void Start()
    {
        //hasLost = false;
        //hasSolved = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (step.hasBlackStep == true)
        {
            //hasLost = true;
            Debug.Log("Player has failed the Step Puzzle");
        }

        if (step.whiteStepNum == 10)
        {
            //hasSolved = true;
            Debug.Log("Player has solved the Step Puzzle");
        }
    }
}
