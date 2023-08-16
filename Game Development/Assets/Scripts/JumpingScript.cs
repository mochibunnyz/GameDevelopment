using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingScript : MonoBehaviour
{

    public GameObject jumping;
    // Start is called before the first frame update
    void Start()
    {
        jumping.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            jumpings();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            stopJumpings();
        }
    }

    void jumpings()
    {
        jumping.SetActive(true);
    }

    void stopJumpings()
    {
        jumping.SetActive(false);
    }
}
