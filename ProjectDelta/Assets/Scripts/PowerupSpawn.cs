using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawn : MonoBehaviour
{
    public GameObject[] powerupPrefabs;
    public GameObject powerupSpawner;
    public int minSpawnCount = 1;
    public int maxSpawnCount = 5;
    public float minDistance = 5f;
    public float maxDistance = 45f;

    private void Start()
    {
        SpawnPowerups();
    }

    private void SpawnPowerups()
    {
        int tspowerupCount = Random.Range(minSpawnCount, maxSpawnCount + 1);
        int pspowerupCount = Random.Range(minSpawnCount, maxSpawnCount + 1);

       // Debug.Log("TS: " + tspowerupCount + " PS: " + pspowerupCount);

        for (int i = 0; i < tspowerupCount; i++)
        {
            SpawnPowerup("TSpowerup");
        }

        for (int i = 0; i < pspowerupCount; i++)
        {
            SpawnPowerup("PSpowerup");
        }
    }

    private void SpawnPowerup(string powerupName)
    {
        GameObject powerupPrefab = GetPowerupPrefab(powerupName);
        if (powerupPrefab == null)
        {
            Debug.LogWarning("Powerup prefab not found for: " + powerupName);
            return;
        }

        Vector2 randomPosition = GetRandomPositionAroundSpawner();
        if (IsPositionValid(randomPosition))
        {
            Collider2D[] existingPowerups = Physics2D.OverlapCircleAll(randomPosition, 10f);
            foreach (Collider2D powerupCollider in existingPowerups)
            {
                if (powerupCollider.CompareTag("powerup"))
                {
                    Vector2 direction = randomPosition - (Vector2)powerupCollider.transform.position;
                    randomPosition += direction.normalized * 10f;
                }
            }

            Instantiate(powerupPrefab, randomPosition, Quaternion.identity);
        }
    }

    private GameObject GetPowerupPrefab(string powerupName)
    {
        foreach (GameObject powerupPrefab in powerupPrefabs)
        {
            if (powerupPrefab.name == powerupName)
            {
                return powerupPrefab;
            }
        }
        return null;
    }

    private Vector2 GetRandomPositionAroundSpawner()
    {
        float distance = Random.Range(minDistance, maxDistance);
        float angle = Random.Range(0f, 360f);

        Vector2 spawnerPosition = powerupSpawner.transform.position;
        Vector2 randomPosition = (Vector3)spawnerPosition + Quaternion.Euler(0f, 0f, angle) * Vector2.up * distance;

        return randomPosition;
    }

    private bool IsPositionValid(Vector2 position)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, 1f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("walls"))
            {
                return false;
            }
        }
        return true;
    }
}
