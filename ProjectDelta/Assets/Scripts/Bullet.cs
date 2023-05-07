using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject explosion;

    // public GameObject hitEffect;
    public int BossBasicDMG = 4, BossSpiralDMG = 2, PulseShotDMG = 3, BasicDMG = 1; 

    private void OnBecameInvisible()
    {
        // Destroy the game object when it goes off screen

        Destroy(gameObject);
       
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
       // Debug.Log("collision with " + collision.gameObject.tag);

        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "meteor" || collision.gameObject.tag == "Player" || collision.gameObject.tag == "Boss")
        {
            //Debug.Log("collision collision");
            var healthComponent = collision.gameObject.GetComponent<Health>();
            if(healthComponent != null) 
            {
                if(gameObject.name.Contains("BossBasicBullet"))
                {
                    healthComponent.takeDamage(BossBasicDMG);
                }
                else if(gameObject.name.Contains("BossSpiralBullet"))
                {
                    healthComponent.takeDamage(BossSpiralDMG);
                }
                else if(gameObject.tag == "pulseShot")
                {
                    healthComponent.takeDamage(PulseShotDMG);
                    // Debug.Log("pulse hit");
                }
                else
                {
                    healthComponent.takeDamage(BasicDMG);
                    // Debug.Log("hit");
                }
            }
        }
        
        Instantiate(explosion,gameObject.transform.position,Quaternion.identity);        
        Destroy(gameObject);
    }
}
