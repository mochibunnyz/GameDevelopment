using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stepPuzzle : MonoBehaviour
{
    
    
    
    public static int whiteStepNum;
    public static bool hasBlackStep;

    

    // Start is called before the first frame update
    void Start()
    {
        
        
        whiteStepNum = 0;
        hasBlackStep = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasBlackStep == true)
        {
            
            Debug.Log("Player has failed the Step Puzzle");
            Destroy(gameObject);
        }

        if (whiteStepNum == 10)
        {
            
            Debug.Log("Player has solved the Step Puzzle");
            Destroy(gameObject);
            


        }
    }


}
