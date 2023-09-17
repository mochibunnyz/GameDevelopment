using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ShowPuzzle4 : MonoBehaviour
{
    public Canvas KeypadCanvas;
    
    [SerializeField] private TextMeshProUGUI interactionMessage;
    public void Start()
    {
        //interaction message is disabled
        interactionMessage.enabled = false;
    }
  
    void OnTriggerStay(Collider other)
    { // the interaction message will appear when the player enters the trigger area
        if (other.CompareTag("Player"))
        {   // The message will trigger to tell the player to press E
            interactionMessage.enabled = true;
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                // the player will have access to the keypad puzzle upon pressing E and interaction message will be disabled
                interactionMessage.enabled = false;
                KeypadCanvas.enabled = true;
                
                //lock cursor
                Cursor.lockState = CursorLockMode.None;
            }
        }
    

    }

    public void EscapeButton()
    {   //the player will be able to escape the keypad puzzle and the prompt interaction message will appear again
        KeypadCanvas.enabled = false;
        interactionMessage.enabled = true;
       
        //Unlock the cursor
        Cursor.lockState = CursorLockMode.Locked;
    }
}

