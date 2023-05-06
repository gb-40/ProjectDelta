using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    private Transform target;
    public float moveSpeed = 5f;
    public float avoidanceDistance = 5f;
    public float desiredDistance = 5f;
    public float repulsionForce = 10f;

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

            // Avoid colliding with other enemies
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, avoidanceDistance);
            foreach (Collider2D collider in colliders)
            {
                if (collider != null && collider.CompareTag("Enemy") && collider != this.GetComponent<Collider2D>())
                {
                    Vector2 avoidDirection = (transform.position - collider.transform.position).normalized;
                    moveDirection += avoidDirection;

                    // Apply repulsion force to nearby enemies
                    float distance = Vector2.Distance(transform.position, collider.transform.position);
                    if (distance < desiredDistance)
                    {
                        Vector2 repulsionVector = (transform.position - collider.transform.position).normalized;
                        moveDirection += repulsionVector * repulsionForce;
                    }
                }
            }

            // Normalize moveDirection after adding avoidance vectors
            moveDirection.Normalize();

            // Move towards or away from the target based on distance
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
