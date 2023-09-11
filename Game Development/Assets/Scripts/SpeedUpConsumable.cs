using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpConsumable : MonoBehaviour
{
    public float boostDuration = 20f;
    public float boostSpeed = 20f;

    private bool isBoostActive = false;
    private float boostEndTime;

    private SimpleSampleCharacterControl playerController;

    private void Start()
    {
        playerController = FindObjectOfType<SimpleSampleCharacterControl>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isBoostActive)
        {
            isBoostActive = true;
            ActivateSpeedBoost();
            gameObject.SetActive(false);
        }
    }

    private void ActivateSpeedBoost()
    {
        isBoostActive = true;
        playerController.SetMoveSpeed(boostSpeed);
        Invoke("DeactivateSpeedBoost", boostDuration);
    }

    private void DeactivateSpeedBoost()
    {
        isBoostActive = false;
        playerController.ResetMoveSpeed();
    }
}
