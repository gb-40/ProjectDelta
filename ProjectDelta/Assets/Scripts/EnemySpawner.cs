using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy {
   // for debug :
   public string Name ;

   public GameObject Prefab ;
   [Range (0f, 100f)]public float Chance = 100f ;

   [HideInInspector] public double _weight ;
}


public class EnemySpawner : MonoBehaviour 
{
   [SerializeField] private Enemy[] enemies ;
   public int enemyCount = 10;

   private double accumulatedWeights ;
   private System.Random rand = new System.Random () ;


   private void Awake () {
      CalculateWeights () ;
   }


   private void Start () {
     
      for (int i = 0; i < enemyCount; i++)
         SpawnRandomEnemy() ;
   }

    private void SpawnRandomEnemy ()
    {
        Enemy randomEnemy = enemies[GetRandomEnemyIndex()];
        
        // Calculate the spawn position range based on the spawner position
        float spawnRangeX = 20f; // Adjust the X range as needed
        float spawnRangeY = 10f; // Adjust the Y range as needed

        Vector2 spawnPosition = transform.position + new Vector3(Random.Range(-spawnRangeX, spawnRangeX), Random.Range(-spawnRangeY, spawnRangeY));

        // Check if the new position is too close to any existing enemy position
        foreach (var enemy in FindObjectsOfType<EnemySpawner>())
        {
            if (Vector2.Distance(spawnPosition, enemy.transform.position) < 5f)
            {
                spawnPosition += new Vector2(Random.Range(-spawnRangeX, spawnRangeX), Random.Range(-spawnRangeY, spawnRangeY));
                break;
            }
        }

        Instantiate(randomEnemy.Prefab, spawnPosition, Quaternion.identity, transform);

        // This line is not required (debug):
       // Debug.Log("<color=" + randomEnemy.Name + ">●</color> Chance: <b>" + randomEnemy.Chance + "</b>%");
    }

   private int GetRandomEnemyIndex () {
      double r = rand.NextDouble () * accumulatedWeights ;

      for (int i = 0; i < enemies.Length; i++)
         if (enemies [ i ]._weight >= r)
            return i ;

      return 0 ;
   }

   private void CalculateWeights () {
      accumulatedWeights = 0f ;
      foreach (Enemy enemy in enemies) {
         accumulatedWeights += enemy.Chance ;
         enemy._weight = accumulatedWeights ;
      }
   }
}
