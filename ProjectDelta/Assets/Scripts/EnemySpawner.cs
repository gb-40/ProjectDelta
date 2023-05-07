using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy
{
    // for debug :
    public string Name;

    public GameObject Prefab;
    [Range(0f, 100f)] public float Chance = 100f;

    [HideInInspector] public double _weight;
}

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy[] enemies;
    public int enemyCount;

    private double accumulatedWeights;
    private System.Random rand = new System.Random();
    public int spawnCount = 0;

    private BossSpawner bossSpawner;

    private void Awake()
    {
        CalculateWeights();
        bossSpawner = GameObject.FindObjectOfType<BossSpawner>();
    }

    private void Start()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            SpawnRandomEnemy();
        }
    }

    private void SpawnRandomEnemy()
    {
        Enemy randomEnemy = enemies[GetRandomEnemyIndex()];

        float spawnRangeX = 20f; // Adjust the X range as needed
        float spawnRangeY = 10f; // Adjust the Y range as needed

        Vector2 spawnPosition = transform.position + new Vector3(Random.Range(-spawnRangeX, spawnRangeX), Random.Range(-spawnRangeY, spawnRangeY));

        foreach (var enemy in FindObjectsOfType<EnemySpawner>())
        {
            if (Vector2.Distance(spawnPosition, enemy.transform.position) < 5f)
            {
                spawnPosition += new Vector2(Random.Range(-spawnRangeX, spawnRangeX), Random.Range(-spawnRangeY, spawnRangeY));
                break;
            }
        }

        Instantiate(randomEnemy.Prefab, spawnPosition, Quaternion.identity, transform);
    }

    private int GetRandomEnemyIndex()
    {
        double r = rand.NextDouble() * accumulatedWeights;

        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i]._weight >= r)
            {
                return i;
            }
        }

        return 0;
    }

    private void CalculateWeights()
    {
        accumulatedWeights = 0f;
        foreach (Enemy enemy in enemies)
        {
            accumulatedWeights += enemy.Chance;
            enemy._weight = accumulatedWeights;
        }
    }

    public void SpawnMoreEnemies()
    {
        if (spawnCount < 4)
        {
            for (int i = 0; i < 5; i++)
            {
                SpawnRandomEnemy();
            }

            foreach (Enemy enemy in enemies)
            {
                enemy.Chance += 5f;
            }

            CalculateWeights();
        }

        spawnCount++;

        if (spawnCount > 4)
        {
            bossSpawner.SpawnBoss();
        }
    }
}
