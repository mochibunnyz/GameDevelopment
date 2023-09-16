using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class ChaseScript : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform playerTransform;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (playerTransform)
        {
            agent.SetDestination(playerTransform.position);
        }
    }
}
