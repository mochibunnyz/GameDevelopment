using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurManager : MonoBehaviour
{
    public enum MinotaurState { PATROL, CHASE }

    public float patrolSpeed = 3f;   // Default patrol speed
    public float chaseSpeed = 4f;      // Speed during chase

    public AudioSource collisionSound; // Drag your AudioSource with the collision sound here
    public GameObject collisionPanel;  // Drag your collision panel here
    public GameObject gameOverPanel;   // Drag your game over panel here

    private UnityEngine.AI.NavMeshAgent agent;
    private PatrolScript patrolScript;
    private ChaseScript chaseScript;
    private MinotaurState currentState;

    void Awake()
    {
        patrolScript = GetComponent<PatrolScript>();
        chaseScript = GetComponent<ChaseScript>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
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
                agent.speed = patrolSpeed;
                break;
            case MinotaurState.CHASE:
                chaseScript.enabled = true;
                agent.speed = chaseSpeed;
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

            // Play Collision Sound
            collisionSound.Play();

            // Display Collision Panel
            collisionPanel.SetActive(true);
        
            // Start the coroutine to hide the collision panel after 2 seconds.
            StartCoroutine(HideCollisionPanelAfterTime(2f));

            collision.gameObject.GetComponent<SimpleSampleCharacterControl>().transform.position = collision.gameObject.GetComponent<SimpleSampleCharacterControl>().startPosition.position;

            if (SimpleSampleCharacterControl.numberOfLives <= 0)
            {
                gameOverPanel.SetActive(true);
            }

            SetState(MinotaurState.PATROL);
        }
    }

    private IEnumerator HideCollisionPanelAfterTime(float delay)
    {
        yield return new WaitForSeconds(delay);
        collisionPanel.SetActive(false);
    }
}
