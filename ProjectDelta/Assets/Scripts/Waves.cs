using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
   public EnemySpawner enemySpawner, enemySpawner1, enemySpawner2, enemySpawner3;

    // Update is called once per frame
   void Update () {
      if(enemySpawner.spawnCount < 5){
         if(GameObject.FindGameObjectsWithTag("Enemy").Length <= 0){
            enemySpawner.SpawnMoreEnemies();
            enemySpawner1.SpawnMoreEnemies();
            enemySpawner2.SpawnMoreEnemies();
            enemySpawner3.SpawnMoreEnemies();
         }
      }
   }
}
