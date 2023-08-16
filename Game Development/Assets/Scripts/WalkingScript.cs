using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingScript : MonoBehaviour
{

    public GameObject walking;
    // Start is called before the first frame update
    void Start()
    {
        walking.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w") && Input.GetKey(KeyCode.LeftShift))
        {
            walkings();
        }
        if (Input.GetKey("s") && Input.GetKey(KeyCode.LeftShift))
        {
            walkings();
        }

        if (Input.GetKeyUp("w"))
        {
            stopWalkings();
        }
        if (Input.GetKeyUp("s"))
        {
            stopWalkings();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            stopWalkings();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            stopWalkings();
        }
    }

    void walkings()
    {
        walking.SetActive(true);
    }

    void stopWalkings()
    {
        walking.SetActive(false);
    }
}
