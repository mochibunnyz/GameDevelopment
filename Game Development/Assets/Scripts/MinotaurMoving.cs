using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurMoving : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float rotationSpeed = 5f;
    private Transform playerTransform;

    public Transform monsterStartPos;
    public int maxCollisions = 5;

    private int collisionCount = 0;

    public GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            playerTransform = player.transform;
        }

        gameOverPanel.SetActive(false);
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Reset positions if collision happens
            other.GetComponent<SimpleSampleCharacterControl>().transform.position = other.GetComponent<SimpleSampleCharacterControl>().startPosition.position;
            transform.position = monsterStartPos.position;

            collisionCount++;

            if (collisionCount >= maxCollisions)
            {
                // Implement game over logic here
                Debug.Log("Game Over");
                // You might want to call a function to show game over UI or reset the scene
                Time.timeScale = 0;
                gameOverPanel.SetActive(true);
            }
        }
    }
}
