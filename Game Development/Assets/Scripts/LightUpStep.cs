using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightUpStep : MonoBehaviour
{
    private Renderer rend;
    private bool hasSteppedOnce;
    public int whiteStepNum;
    public bool hasBlackStep; 
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        hasSteppedOnce = false;
        hasBlackStep = false;

    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player" && hasSteppedOnce == false)
        {
            rend.material.color = Color.white;
            hasSteppedOnce = true;
            whiteStepNum++; 
        }

        if (collider.tag == "Player" && hasSteppedOnce == true)
        {
            rend.material.color = Color.black;
            hasBlackStep = false; 
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
