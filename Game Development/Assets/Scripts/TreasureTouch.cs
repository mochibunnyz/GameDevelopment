using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureTouch : MonoBehaviour
{
    public GameObject treasuretouch;
    public GameObject treasurePanel;
    public float TDuration = 5f;
    private bool isActivated = false;

    public Transform storagePos;

    // Start is called before the first frame update
    void Start()
    {
        treasuretouch.SetActive(false);
        treasurePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            transform.position = storagePos.position;
            SimpleSampleCharacterControl.numberOfTreasures += 1;
            Debug.Log("Treasures Obtained:" + SimpleSampleCharacterControl.numberOfTreasures);

            

            if (!isActivated)
            {
                isActivated = true;
                ActivateForDuration();
            }

        }
    }

    private void ActivateForDuration()
    {
        treasurePanel.SetActive(true);
        treasuretouch.SetActive(true);
        Invoke("DeactivateObject", TDuration);
    }

    private void DeactivateObject()
    {
        treasurePanel.SetActive(false);
        treasuretouch.SetActive(false);
        isActivated = false;
    }


}
