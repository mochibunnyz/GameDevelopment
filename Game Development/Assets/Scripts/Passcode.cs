using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Passcode : MonoBehaviour
{
    [SerializeField] private GameObject RewardButton;
    string Code = "302";
    string Nr = null;
    int NrIndex = 0;
    string aplha;
    public Text UiText = null;

    public void CodeFunction(string Numbers)
    {
        NrIndex++;
        Nr = Nr + Numbers;
        UiText.text = Nr;
    }

    public void Enter()
    {
        if(Nr == Code)
        {
            UiText.text = "Correct";
            RewardButton.SetActive(true);
        }
        else if(Nr != Code)
        {
            UiText.text = "Try again";
            
            
        }
    }

    public void Delete()
    {
        NrIndex++;
        Nr = null;
        UiText.text = Nr;
    }
}
