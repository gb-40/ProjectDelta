using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject explosion;
    private LevelScript levelScript;
    private Animator anim;
    private GameObject cam; 
     public int BossBasicDMG = 4, BossSpiralDMG = 2, PulseShotDMG = 3, BasicDMG = 1; 

    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }
    private void OnBecameInvisible()
    {
        // Destroy the game object when it goes off screen

        Destroy(gameObject);
       
    }

     void OnCollisionEnter2D(Collision2D collision) 
    {
       // Debug.Log("collision with " + collision.gameObject.tag);

        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "meteor" || collision.gameObject.tag == "Boss")
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
                   //  levelScript.SubtractTime(PulseShotDMG);
                    healthComponent.takeDamage(PulseShotDMG);
                    // Debug.Log("pulse hit");
                }
                else
                {
                    healthComponent.takeDamage(BasicDMG);
                   // levelScript.SubtractTime(BasicDMG);
                    // Debug.Log("hit");
                }
            }

        
        }

        if(collision.gameObject.tag == "Player")
        {
           Animator anim = collision.gameObject.GetComponent<Animator>();
           Animator camAnim = cam.GetComponent<Animator>();
           

            levelScript = GameObject.FindObjectOfType<LevelScript>();
            if(levelScript != null) 
            {
            if(gameObject.name.Contains("BossBasicBullet"))
                {
                    levelScript.SubtractTime(BossBasicDMG);
                    anim.SetTrigger("playerHurt");
                   
    

                    
                }
                else if(gameObject.name.Contains("BossSpiralBullet"))
                {
                   levelScript.SubtractTime(BossSpiralDMG);
                   anim.SetTrigger("playerHurt");
                  
                }

                else if(gameObject.tag == "pulseShot")
                {
                   //  levelScript.SubtractTime(PulseShotDMG);
                   levelScript.SubtractTime(PulseShotDMG);
                    // Debug.Log("pulse hit");
                    anim.SetTrigger("playerHurt");
                    
                }
                else
                {
                  levelScript.SubtractTime(BasicDMG);
                   // levelScript.SubtractTime(BasicDMG);
                    // Debug.Log("hit");
                    anim.SetTrigger("playerHurt");
                   
                }
            }
        }
    
    
        Instantiate(explosion, transform.position, Quaternion.identity);         
        Destroy(gameObject);
        // Destroy(effect, 5f);
    }
}
