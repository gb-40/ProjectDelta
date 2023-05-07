using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float range = 45f; 
    public float speedX = 3f; 
    private float speedY = 3f; 
    public float metorDamage= 2f;
   
   private float rotateSpeed = 80f;
   private Health health;
   private Animator anim; 
   private Collider2D col;
   public GameObject smoke;
   private LevelScript levelScript;
  
 
    // Start is called before the first frame update
    void Start()
    {
       speedY= Random.Range(-2f, 2f); 
       health = GetComponent<Health>();
       anim = GetComponent<Animator>(); 
       col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
     
       transform.position += new Vector3(speedX * Time.deltaTime, speedY * Time.deltaTime, 0f);
       transform.Rotate(Vector3.forward,Time.deltaTime * rotateSpeed);
        if (health.currentHealth <= 0)
        {
          Death();
        }
      
    }
        

    private void OnCollisionEnter2D(Collision2D other)
    {
      
        {
        if(other.gameObject.CompareTag("meteor") ||other.gameObject.CompareTag("walls") )
        {
            speedX = -speedX;
            speedY= -speedY;

            rotateSpeed = Random.Range(-100f,80f);
        }
        }

        if(other.gameObject.CompareTag("Player"))
        {
            levelScript = GameObject.FindObjectOfType<LevelScript>();
            levelScript.SubtractTime(metorDamage);
        }
    
    }
     private void Death()
    {


      Instantiate(smoke, transform.position, Quaternion.identity);

        // Destroy the game object
        Destroy(gameObject);
    }
}


