using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    public Transform[] waypoints;
    public Transform player;
    public float chaseDistance = 10f;
    public float sightRayLength = 10f;
    public float stopChaseDistance = 20f;

    private NavMeshAgent agent;
    private int destPoint = 0;
    private enum State { Patrolling, Chasing };
    private State state = State.Patrolling;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        GoToNextWaypoint();
    }

    void Update()
    {
        switch (state)
        {
            case State.Patrolling:
                if (!agent.pathPending && agent.remainingDistance < 0.5f)
                {
                    GoToNextWaypoint();
                }

                if (CanSeePlayer())
                {
                    Debug.Log("Player detected!");
                    state = State.Chasing;
                }
                break;

            case State.Chasing:
                agent.destination = player.position;

                if (Vector3.Distance(transform.position, player.position) > stopChaseDistance || !NavMesh.SamplePosition(player.position, out NavMeshHit hit, 1f, NavMesh.AllAreas))
                {
                    Debug.Log("Lost the player. Returning to patrol.");
                    state = State.Patrolling;
                    GoToNextWaypoint();
                }
                break;
        }
    }

    bool CanSeePlayer()
    {
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        Vector3 rayOrigin = transform.position + Vector3.up; // 1 unit above the ground

        // Debugging ray
        Debug.DrawRay(rayOrigin, directionToPlayer * sightRayLength, Color.red, 2f);

        if (Vector3.Distance(player.position, transform.position) < chaseDistance)
        {
            if (Physics.Raycast(rayOrigin, directionToPlayer, out RaycastHit hit, sightRayLength))
            {
                Debug.Log("Raycast hit: " + hit.transform.name);

                if (hit.transform == player)
                {
                    return true;
                }
            }
        }
        return false;
    }

    void GoToNextWaypoint()
    {
        if (waypoints.Length == 0)
            return;

        agent.destination = waypoints[destPoint].position;
        destPoint = (destPoint + 1) % waypoints.Length;
    }
}