using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed at which the enemy moves
    public float minMoveDistance = 1f; // Minimum distance to move before selecting a new random position

    private Vector3 targetPosition; // The current target position for the enemy

    private void Start()
    {
        // Set the initial target position
        targetPosition = GetRandomPosition();
    }

    private void Update()
    {
        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Check if the enemy has reached the target position
        if (Vector3.Distance(transform.position, targetPosition) < minMoveDistance)
        {
            // Select a new random position
            targetPosition = GetRandomPosition();
        }
    }

    private Vector3 GetRandomPosition()
    {
        // Generate a random position within a specified range
        Vector3 randomPosition = new Vector3(Random.Range(-10f, 10f), 0f, Random.Range(-10f, 10f));

        return randomPosition;
    }
}