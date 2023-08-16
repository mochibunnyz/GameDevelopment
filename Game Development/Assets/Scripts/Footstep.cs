using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footstep : MonoBehaviour
{

    public GameObject footstep;

    // Start is called before the first frame update
    void Start()
    {
        footstep.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow))
        {
            footSteps();
        }
        if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow))
        {
            footSteps();
        }


        if (Input.GetKeyUp("w") || Input.GetKeyUp(KeyCode.UpArrow))
        {
            stopFootSteps();
        }
        if (Input.GetKeyUp("s") || Input.GetKeyUp(KeyCode.DownArrow))
        {
            stopFootSteps();
        }

        
    }

    void footSteps()
    {
        footstep.SetActive(true);
    }

    void stopFootSteps()
    {
        footstep.SetActive(false);
    }

    
}
