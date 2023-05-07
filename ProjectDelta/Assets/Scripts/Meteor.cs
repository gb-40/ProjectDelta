using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float range = 45f; 
    public float speedX = 3f; 
    private float speedY = 3f; 
   
   private float rotateSpeed = 80f;
   private Health health;
   private Animator explosionAnim; 

   private Collider2D col;
  
 
    // Start is called before the first frame update
    void Start()
    {
       speedY= Random.Range(-2f, 2f); 
       health = GetComponent<Health>();
       Transform childTransform = transform.Find("Explosion"); 
       explosionAnim = childTransform.GetComponent<Animator>();
       col = GetComponent<Collider2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
     
       transform.position += new Vector3(speedX * Time.deltaTime, speedY * Time.deltaTime, 0f);
       transform.Rotate(Vector3.forward,Time.deltaTime * rotateSpeed);
        if (health.currentHealth <= 0)
        {
           StartCoroutine(Destroy());
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
    
    }
     IEnumerator Destroy()
    {
        // Do death animation and sound effects
       // Debug.Log("Enemy has died!");
       // pathing.enabled = false;
      

        //play animation 
        
       explosionAnim.SetTrigger("destroy");
       speedX = 0f; speedY = 0f; 
        col.enabled = false; 


        // Wait for the death animation to finish
        yield return new WaitForSeconds(1f);

        // Destroy the game object
        Destroy(gameObject);
    }
}


