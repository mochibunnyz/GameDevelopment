using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurManager : MonoBehaviour
{
    public enum MinotaurState { PATROL, CHASE }

    public Transform playerSpawnPoint; // Drag the player's spawn point here in the inspector

    private PatrolScript patrolScript;
    private ChaseScript chaseScript;
    private MinotaurState currentState;

    void Awake()
    {
        patrolScript = GetComponent<PatrolScript>();
        chaseScript = GetComponent<ChaseScript>();
    }

    void Start()
    {
        SetState(MinotaurState.PATROL);
    }

    public void SetState(MinotaurState newState)
    {
        switch (currentState)
        {
            case MinotaurState.PATROL:
                patrolScript.enabled = false;
                break;
            case MinotaurState.CHASE:
                chaseScript.enabled = false;
                break;
        }

        switch (newState)
        {
            case MinotaurState.PATROL:
                patrolScript.enabled = true;
                break;
            case MinotaurState.CHASE:
                chaseScript.enabled = true;
                break;
        }

        currentState = newState;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SetState(MinotaurState.CHASE);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SetState(MinotaurState.PATROL);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SimpleSampleCharacterControl.numberOfLives -= 1;
            collision.gameObject.transform.position = playerSpawnPoint.position;
            SetState(MinotaurState.PATROL);
        }
    }
}