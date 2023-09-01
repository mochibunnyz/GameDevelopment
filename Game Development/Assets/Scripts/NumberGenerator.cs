using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class NumberGenerator : MonoBehaviour,IInteractable
{
    public TMP_Text puzzleText;

   
    public void start()
    {
        puzzleText = GetComponent<TextMeshProUGUI>();

    }
    public void Interact()
    {
        puzzleText.text = "text";
    }

    
  
}
