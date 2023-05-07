using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forEnemy : MonoBehaviour
{
    private Health health;
   // private int maxHealth = 100;  
    private Animator anim; 
    private Rigidbody2D rb; 
    private EnemyPathing pathing;
    


    // Start is called before the first frame update
    
void Start()
    {
        health = GetComponent<Health>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        pathing = GetComponent<EnemyPathing>();
        
    }

    // Update is called once per frame
    void Update()
    {
          if (health.currentHealth <= 0)
        {
            StartCoroutine(Death());
        }
    }

     IEnumerator Death()
    {
        // Do death animation and sound effects
        Debug.Log("Enemy has died!");
        pathing.enabled = false;
      

        //play animation 
        anim.SetTrigger("dead");


        // Wait for the death animation to finish
        yield return new WaitForSeconds(1f);

        // Destroy the game object
        Destroy(gameObject);
    }





}
