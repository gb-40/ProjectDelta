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

    public GameObject explosionPrefab;
    public float radius = 4f;
    public int numExplosions = 4;
    public float explosionDuration = 4f;

    private LevelScript levelScript;

    private Health health;

    public string WinMSG = "Win";   


    private void Start()
    {
        GenerateRandomMovement();
        health = GetComponent<Health>();

      levelScript = GameObject.FindObjectOfType<LevelScript>();
      levelScript.DisplayBossHealth();

      

      
     

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
        
        if (health.currentHealth <= 0)
        {
            Death();
            levelScript.EndGame(WinMSG);
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

    private void Death()
    {
         for (int i = 0; i < numExplosions; i++)
        {
            // Generate a random position within the radius
            Vector3 position = Random.insideUnitSphere * radius;
            position += transform.position;

            // Instantiate the explosion prefab at the random position
            GameObject explosion = Instantiate(explosionPrefab, position, Quaternion.identity);

            // Destroy the explosion after the specified duration
            Destroy(explosion, explosionDuration);
        }
        Destroy(gameObject);
    }
}
