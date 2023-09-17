using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject mainMenuPanel; // Drag your main menu UI panel here in the inspector
    
    private void Start()
    {
        ReinitializeMenu();
    }
    
    public void ReinitializeMenu()
    {
        // Ensure the main menu UI is active
        mainMenuPanel.SetActive(true);
    }
}