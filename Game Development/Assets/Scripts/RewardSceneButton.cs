using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RewardSceneButton : MonoBehaviour
{
    [SerializeField] private string newLevel;
    [SerializeField] private GameObject RewardButton;
    // Start is called before the first frame update
    void Start()
    {
        RewardButton.SetActive(false);
    }

    
   

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(newLevel);

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;


            }
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
