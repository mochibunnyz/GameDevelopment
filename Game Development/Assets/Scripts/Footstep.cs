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
        if (Input.GetKey("w") && !Input.GetKey(KeyCode.LeftShift))
        {
            footSteps();
        }
        if (Input.GetKey("s") && !Input.GetKey(KeyCode.LeftShift))
        {
            footSteps();
        }


        if (Input.GetKeyUp("w"))
        {
            stopFootSteps();
        }
        if (Input.GetKeyUp("s"))
        {
            stopFootSteps();
        }

        if (Input.GetKey(KeyCode.Space))
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
