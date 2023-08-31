using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalAchieved : MonoBehaviour
{
    public GameObject goalPanel;
    public GameObject goalSound;
    public float GDuration = 5f;
    private bool isActivated = false;

    // Start is called before the first frame update
    void Start()
    {
        goalPanel.SetActive(false);
        goalSound.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && SimpleSampleCharacterControl.numberOfTreasures == 5)
        {
            goalPanel.SetActive(true);
            Time.timeScale = 0;
            if (!isActivated)
            {
                isActivated = true;
                ActivateForDuration();
            }
        }
    }

    private void ActivateForDuration()
    {
        goalSound.SetActive(true);
        Invoke("DeactivateObject", GDuration);
    }

    private void DeactivateObject()
    {
        goalSound.SetActive(false);
        isActivated = false;
    }
}
