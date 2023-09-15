using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurMoving : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float rotationSpeed = 5f;
    private Transform playerTransform;

    public Transform monsterStartPos;
    public int maxCollisions = 5;

    private int collisionCount = 0;

    public GameObject gameOverPanel;
    public GameObject collisionPanel;
    public float CPDuration = 5f;
    private bool isActivated = false;

    public GameObject collisionSound;
    public Collider boundaryCollider;
    public bool playerInArea = false;

    private Vector3 randomDirection;
    private Quaternion targetRotation;


    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            playerTransform = player.transform;
        }

        gameOverPanel.SetActive(false);
        collisionPanel.SetActive(false);
        collisionSound.SetActive(false);

        GenerateRandomDirection();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null && playerInArea == true)
        {
            Vector3 directionToPlayer = playerTransform.position - transform.position;
            Vector3 moveDirection = directionToPlayer.normalized;

            //rotating towards the direction of the player
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            //auto moving the minotaur towards the player
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        }
        else if (playerInArea == false)
        {
            targetRotation = Quaternion.LookRotation(randomDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Move in the current random direction
            transform.Translate(randomDirection * moveSpeed * Time.deltaTime);

            // Optionally, change direction at random intervals
            if (Random.Range(0f, 1f) < 0.02f) // Change direction with a 2% chance per frame
            {
                GenerateRandomDirection();
            }
        }

        if (!boundaryCollider.bounds.Contains(transform.position))
        {
            //if it's outside, clamp the position to stay inside the boundary
            Vector3 clampedPosition = transform.position;
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, boundaryCollider.bounds.min.x, boundaryCollider.bounds.max.x);
            clampedPosition.z = Mathf.Clamp(clampedPosition.z, boundaryCollider.bounds.min.z, boundaryCollider.bounds.max.z);
            transform.position = clampedPosition;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //reset positions if collision happens
            other.GetComponent<SimpleSampleCharacterControl>().transform.position = other.GetComponent<SimpleSampleCharacterControl>().startPosition.position;
            transform.position = monsterStartPos.position;

            collisionCount++;
            SimpleSampleCharacterControl.numberOfLives -= 1;



            if (!isActivated)
            {
                isActivated = true;
                ActivateForDuration();
            }


            if (collisionCount >= maxCollisions)
            {
                Debug.Log("Game Over");
                Time.timeScale = 0;
                gameOverPanel.SetActive(true);
            }
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
        isActivated = false;
    }

    void GenerateRandomDirection()
    {
        // Generate a new random direction
        randomDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
    }
}
