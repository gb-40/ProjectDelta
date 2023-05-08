using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forEnemy : MonoBehaviour
{
     private LevelScript levelScript;
   // private int maxHealth = 100;  

    private Rigidbody2D rb; 
   
   
    public GameObject enemyExplosion; 
      private Health health;
    


    // Start is called before the first frame update
    
void Start()
    {
        health = GetComponent<Health>();
    

        levelScript = GameObject.FindObjectOfType<LevelScript>();
 
    }
    

    // Update is called once per frame
    void Update()
    {
          if (health.currentHealth <= 0)
        {
            Death();
        }
    }

     void Death()
    {
        Instantiate(enemyExplosion,transform.position,Quaternion.identity);
        
        Destroy(gameObject);
        levelScript.AddTime(2f);
    }
}
