using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SceneLoaderForKeypad : MonoBehaviour
{
    [SerializeField] private string newLevel;
    

  
    

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
