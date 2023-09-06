using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightUpStep : MonoBehaviour
{
    private Renderer rend;
    private bool hasSteppedOnce;
    public int whiteStepNum;
    public bool hasBlackStep;
    public GameObject tiletouch;

    //public Material Solved;
    public Material steppedMaterial;
    public Material BlackMaterial;

    // Start is called before the first frame update
    void Start()
    {
        
        hasSteppedOnce = false;
        
        tiletouch.SetActive(false);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
           
            if (hasSteppedOnce == false)
            {
                transform.GetComponent<Renderer>().material = steppedMaterial;
                hasSteppedOnce = true;
                stepPuzzle.whiteStepNum++;
                Debug.Log("player stepped on a tile");
                tileTouch();
            }
            else
            {
                Debug.Log("player stepped on the same tile twice");
                stepPuzzle.hasBlackStep = true;
                transform.GetComponent<Renderer>().material = BlackMaterial;
                other.GetComponent<SimpleSampleCharacterControl>().transform.position = other.GetComponent<SimpleSampleCharacterControl>().tilePuzzleResetPosition.position;
            }
        }

        


    }

    void tileTouch()
    {
        tiletouch.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Reset the tile to its initial state
    public void ResetTile()
    {
        hasSteppedOnce = false;
        tiletouch.SetActive(false);
    }
}
