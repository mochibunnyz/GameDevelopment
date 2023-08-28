using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurMoving : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float rotationSpeed = 5f;
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null)
        {
            Vector3 directionToPlayer = playerTransform.position - transform.position;
            Vector3 moveDirection = directionToPlayer.normalized;

            // rotating towards the direction of the player
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // auto moving the minotaur towards the player
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        }
    }
}
