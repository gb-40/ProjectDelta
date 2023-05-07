using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    private Vector2 currentDirection;
    private float currentMovementTime;
    private float currentTimer;

    public float moveSpeed = 5f;
    public float minMoveDuration = 1f;
    public float maxMoveDuration = 3f;


    private void Start()
    {
        GenerateRandomMovement();
    }

    private void Update()
    {
        if (currentTimer >= currentMovementTime)
        {
            GenerateRandomMovement();
        }
        else
        {
            currentTimer += Time.deltaTime;
            MoveBoss();
        }
    }

    private void GenerateRandomMovement()
    {
        currentDirection = Random.insideUnitCircle.normalized;
        currentMovementTime = Random.Range(minMoveDuration, maxMoveDuration);
        currentTimer = 0f;
    }

    private void MoveBoss()
    {
        transform.Translate(currentDirection * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("OuterWalls"))
        {
            Vector2 collisionNormal = collision.GetContact(0).normal;
            currentDirection = Vector2.Reflect(currentDirection, collisionNormal).normalized;
        }
    }
}
