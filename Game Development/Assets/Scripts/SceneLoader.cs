using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class SceneLoader : MonoBehaviour
{
    
    [SerializeField] private string newLevel;
    [SerializeField] private TextMeshProUGUI interactionMessage;
    
    void Start()
    {
        interactionMessage.enabled = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactionMessage.enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(newLevel);
                
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                
            }
        }
        else
        {
            interactionMessage.enabled = false;
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

  
}
