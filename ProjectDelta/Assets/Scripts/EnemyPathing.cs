using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    private Transform target;
    public float moveSpeed = 5f;
    public float avoidanceDistance = 5f;
    public float desiredDistance = 500f;                                // FIX THIS

    private void Start()
    {
        target = playerMovement.Instance;
        if (target == null)
        {
            Debug.LogError("Player target not found!");
        }
    }

    private void Update()
    {
        if (target != null)
        {
            Vector2 direction = target.position - transform.position;
            Vector2 moveDirection = direction.normalized;

            // Check for collision using Raycast
            RaycastHit2D hit = Physics2D.Raycast(transform.position, moveDirection, avoidanceDistance);
            if (hit.collider != null)
            {
                // Calculate a new direction perpendicular to the obstacle
                Vector2 avoidDirection = Vector2.Perpendicular(moveDirection);

                // Move in the avoidDirection instead of the original moveDirection
                transform.Translate(avoidDirection * moveSpeed * Time.deltaTime);
            }
            else
            {
                // No collision, move towards the target normally
                transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
            }

            // Buffer between enemy and player
            float distanceToTarget = direction.magnitude;

            if (distanceToTarget > desiredDistance)
            {
                // Move towards the target if the distance is greater than desiredDistance
                transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
            }
            else if (distanceToTarget < desiredDistance)
            {
                // Move away from the target if the distance is smaller than desiredDistance
                transform.Translate(-moveDirection * moveSpeed * Time.deltaTime);
            }
        }
    }
}