using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    public Canvas PressE;
    public Canvas Puzzle;
    public RingPuzzleController ringPuzzleController; // Reference to the RingPuzzleController
    //public CharacterController PlayerCharacter;

    void OnTriggerEnter(Collider EntityEnter)
    {
        // Check if the puzzle is already solved
        if (ringPuzzleController.PuzzleSolved)
            return;
        
        //check if its player
        if(EntityEnter.tag=="Player")
        {
            Debug.Log("The player entered trigger area");
            //shows the press E prompt
            PressE.enabled = true;

        }

        ringPuzzleController.OnPuzzleSolved += HandlePuzzleSolved;

    }

    void OnTriggerExit(Collider EntityExit)
    {
        //check if its player
        if(EntityExit.tag == "Player")
        {
            //hide the press E prompt
            PressE.enabled = false;
            Puzzle.enabled = false;
            //remove access to cursor
            //Cursor.lockState = CursorLockMode.Locked;

        }

        ringPuzzleController.OnPuzzleSolved += HandlePuzzleSolved;
    }

    void OnTriggerStay(Collider EntityIn)
    {
        //check if its player
        if(EntityIn.tag == "Player")
        {
            //press E to open canvas
            if(Input.GetKey(KeyCode.E))
            {
                Debug.Log("The player press E");
                Puzzle.enabled = true;
                PressE.enabled = false;
                //stop player from moving
                //PlayerCharacter.enabled = false;

                //stop enemy from moving

                //give access to mouse cursor
                //Cursor.lockState = CursorLockMode.None;
            }
            if(Input.GetKey(KeyCode.Escape))
            {
                EscapeCanvas();
            }
        }
    }
    public void EscapeCanvas()
    {
        Debug.Log("Player pressed escape");
                //close canvas
                Puzzle.enabled = false;
                PressE.enabled = true;

                //lock mouse
                //Cursor.lockState = CursorLockMode.Locked;

                //stop player from moving
                //PlayerCharacter.enabled = true;
    }

    void HandlePuzzleSolved()
    {
        PressE.enabled = false;  // Hide the press E prompt immediately.
        // If you also want to close the puzzle canvas, you can add:
        Puzzle.enabled = false;
    }


}
