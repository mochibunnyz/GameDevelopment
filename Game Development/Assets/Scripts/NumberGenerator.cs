using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class NumberGenerator : MonoBehaviour,IInteractable
{
    public TMP_Text canvasText;

    public string textVariable = "Some Text 2";
    public int TheNumber;
    public void start()
    {
        

    }
    public void ChangeNumbers()
    {
        canvasText.text = textVariable;
    }
    public void Interact()
    {
        //Debug.Log(Random.Range(0, 100));
        ChangeNumbers();


    }
    
  
}
