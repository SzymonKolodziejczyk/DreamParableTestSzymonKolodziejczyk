using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed at which the enemy moves

    private Vector3 MoveDirection; // The current movement direction for the enemy

    private void Start()
    {
        // Set the initial movement direction
        MoveDirection = GetRandomDirection();
    }

    private void Update()
    {
        // Move in the current direction
        Vector3 newPosition = transform.position + MoveDirection * moveSpeed * Time.deltaTime;
        newPosition.y = transform.position.y; // Freeze the y-axis position
        transform.position = newPosition;

        // Check if the enemy has collided with a wall or other object
        RaycastHit hit;
        if (Physics.Raycast(transform.position, MoveDirection, out hit, 1f))
        {
            // Reflect the movement direction
            MoveDirection = Vector3.Reflect(MoveDirection, hit.normal);
        }
    }

    private Vector3 GetRandomDirection()
    {
        // Generate a random direction
        Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;

        return randomDirection;
    }
}