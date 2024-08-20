using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuColorMovement : MonoBehaviour
{
    public float moveSpeed = 2f;           // Speed of movement
    public float changeDirectionTime = 2f; // Time after which direction changes
    public float rotationSpeed = 5f;       // Speed of rotation towards the new direction

    private Vector2 moveDirection;
    private Vector2 targetDirection;
    private float timeSinceDirectionChange = 0f;

    void Start()
    {
        // Initial random direction
        ChangeDirection();
        moveDirection = targetDirection; // Start by moving directly in the initial direction
    }

    void Update()
    {
        // Smoothly rotate towards the target direction
        moveDirection = Vector2.Lerp(moveDirection, targetDirection, rotationSpeed * Time.deltaTime);
        moveDirection.Normalize(); // Ensure the direction vector remains normalized

        // Move the object in the current direction
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // Update the time since direction was last changed
        timeSinceDirectionChange += Time.deltaTime;

        // Change direction after the specified time
        if (timeSinceDirectionChange > changeDirectionTime)
        {
            ChangeDirection();
            timeSinceDirectionChange = 0f;
        }
    }

    void ChangeDirection()
    {
        // Generate a new random target direction
        float randomAngle = Random.Range(0f, 360f);
        targetDirection = new Vector2(Mathf.Cos(randomAngle * Mathf.Deg2Rad), Mathf.Sin(randomAngle * Mathf.Deg2Rad));
    }
}
