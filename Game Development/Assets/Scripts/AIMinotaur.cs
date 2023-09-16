using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMinotaur : MonoBehaviour
{
    public float detectionRadius = 5f;
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;
    
    private NavMeshAgent agent;
    private Transform playerTransform;

    public Transform monsterStartPos;

    public GameObject gameOverPanel;
    public GameObject collisionPanel;
    public float CPDuration = 5f;

    public GameObject collisionSound;
    public bool playerInArea = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }

        gameOverPanel.SetActive(false);
        collisionPanel.SetActive(false);
        collisionSound.SetActive(false);

        agent.SetDestination(waypoints[currentWaypointIndex].position);
    }

    void Update()
    {
        if (playerInArea && playerTransform != null)
        {
            agent.SetDestination(playerTransform.position);
        }
        else
        {
            Patrol();
        }
    }

    void Patrol()
    {
        if (agent.remainingDistance < 0.5f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            agent.SetDestination(waypoints[currentWaypointIndex].position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInArea = true;
            ActivateForDuration();
            SimpleSampleCharacterControl.numberOfLives -= 1;

            if (SimpleSampleCharacterControl.numberOfLives <= 0)
            {
                Debug.Log("Game Over");
                Time.timeScale = 0;
                gameOverPanel.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInArea = false;
            agent.SetDestination(waypoints[currentWaypointIndex].position); // Resume patrolling
        }
    }

    private void ActivateForDuration()
    {
        collisionPanel.SetActive(true);
        collisionSound.SetActive(true);
        Invoke("DeactivateObject", CPDuration);
    }

    private void DeactivateObject()
    {
        collisionPanel.SetActive(false);
        collisionSound.SetActive(false);
    }
}