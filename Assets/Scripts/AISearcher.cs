using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISearcher : MonoBehaviour
{
    public int moveSpeed = 5;
    private Vector2 currentDirection;
    private bool isColliding = false;

    private void Start()
    {
        currentDirection = Vector2.right; // Start moving in the right direction
    }

    private void Update()
    {
        if (!isColliding)
        {
            Move();
        }
    }

    private void Move()
    {
        Vector2 newPosition = (Vector2)transform.position + (currentDirection * moveSpeed * Time.deltaTime);
        transform.position = newPosition;
    }

    private IEnumerator ReverseMovement(float duration)
    {
        isColliding = true;
        Vector2 reverseDirection = -currentDirection;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            Vector2 newPosition = (Vector2)transform.position + (reverseDirection * moveSpeed * Time.deltaTime);
            transform.position = newPosition;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        isColliding = false;
        ChangeDirection();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("AED"))
        {
            moveSpeed = 0;
            Destroy(other.gameObject);
        }
        else
        {
            StartCoroutine(ReverseMovement(0.2f));
        }
    }

    private void ChangeDirection()
    {
        // Generate a new random direction
        Vector2[] directions = { Vector2.up, Vector2.down, Vector2.left, Vector2.right };
        List<Vector2> availableDirections = new List<Vector2>();

        foreach (Vector2 direction in directions)
        {
            if (direction != currentDirection) // Exclude the opposite direction
            {
                availableDirections.Add(direction);
            }
        }

        int randomIndex = Random.Range(0, availableDirections.Count);
        currentDirection = availableDirections[randomIndex];
    }
}