using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightUpStep : MonoBehaviour
{
    public bool hasSteppedOnce;
    public GameObject tiletouch;

    public stepPuzzle puzzleScript;

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
                hasSteppedOnce = true;
                puzzleScript.TileSteppedOn(gameObject);
                stepPuzzle.whiteStepNum++;
                Debug.Log("player stepped on a tile");
                tileTouch();
            }
            else
            {
                Debug.Log("player stepped on the same tile twice");
                stepPuzzle.hasBlackStep = true;
                other.GetComponent<SimpleSampleCharacterControl>().transform.position = other.GetComponent<SimpleSampleCharacterControl>().tilePuzzleResetPosition.position;
            }
        }

    }

    void tileTouch()
    {
        tiletouch.SetActive(true);
    }
}
