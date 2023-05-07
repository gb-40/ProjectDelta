using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    public EnemySpawner enemySpawner, enemySpawner1;

    // Update is called once per frame
   void Update () {
      if(GameObject.FindGameObjectsWithTag("Enemy").Length <= 0){
         enemySpawner.SpawnMoreEnemies();
         enemySpawner1.SpawnMoreEnemies();
      }
   }
}
