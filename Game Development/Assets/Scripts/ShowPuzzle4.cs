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
        interactionMessage.enabled = false;
    }
  
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactionMessage.enabled = true;

            if (Input.GetKeyDown(KeyCode.E))
            {
                interactionMessage.enabled = false;
                KeypadCanvas.enabled = true;
                
               
                Cursor.lockState = CursorLockMode.None;
            }
        }
    

    }

    public void EscapeButton()
    {
        KeypadCanvas.enabled = false;
        interactionMessage.enabled = true;
       
        //Unlock the cursor
        Cursor.lockState = CursorLockMode.Locked;
    }
}

