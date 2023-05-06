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

    private Vector2 randomDirection;
    private float changeDirectionInterval = 1f;
    private float changeDirectionTimer;

    private void Start()
    {
        target = playerMovement.Instance;
        if (target == null)
        {
            Debug.LogError("Player target not found!");
        }

        changeDirectionTimer = changeDirectionInterval;
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

            // Rotate towards the target
            if (direction != Vector2.zero)
            {
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }

            // Move towards or away from the target based on distance
            float distanceToTarget = direction.magnitude;
            if (distanceToTarget > desiredDistance)
            {
                // Move towards the target if the distance is greater than desiredDistance
                transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
            }
            else if (distanceToTarget < desiredDistance)
            {
                // Move away from the target if the distance is smaller than desiredDistance
                transform.Translate(-moveDirection * moveSpeed * Time.deltaTime, Space.World);
            }

            // Change direction randomly
            changeDirectionTimer -= Time.deltaTime;
            if (changeDirectionTimer <= 0)
            {
                randomDirection = Random.insideUnitCircle.normalized;
                changeDirectionTimer = changeDirectionInterval;
            }

            // Add random movement to the enemy
            moveDirection += randomDirection;
            moveDirection.Normalize();
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
        }
    }
}
