using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    // public GameObject hitEffect;

    private void OnBecameInvisible()
    {
        // Destroy the game object when it goes off screen
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
       // Debug.Log("collision with " + collision.gameObject.tag);

        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "meteor" || collision.gameObject.tag == "Player")
        {
            //Debug.Log("collision collision");
            var healthComponent = collision.gameObject.GetComponent<Health>();
            if(healthComponent != null) 
            {
                if(gameObject.tag == "pulseShot")
                {
                    healthComponent.takeDamage(3);
                    Debug.Log("pulse hit");
                    Destroy(gameObject);
                }
                else
                {
                    healthComponent.takeDamage(1);
                    Debug.Log("hit");
                    Destroy(gameObject);
                }
            }
        }
    
        // GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        // Destroy(effect, 5f);
    }
}
