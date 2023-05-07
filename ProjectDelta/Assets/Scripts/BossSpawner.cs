using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bossPrefab;
    private static bool bossSpawned = false;

    public void SpawnBoss()
    {
        if (!bossSpawned)
        {
            Vector2 spawnPosition = transform.position;
            Instantiate(bossPrefab, spawnPosition, Quaternion.identity);
            bossSpawned = true;
        }
    }
}
