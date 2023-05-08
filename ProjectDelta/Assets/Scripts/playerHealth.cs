using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{ 
    // private Health health; 

    // // Start is called before the first frame update
    // void Start()
    // {
    //     health = GetComponentInChildren<Health>(); 
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
    private LevelScript levelScript;
   // private int maxHealth = 100;  

    private Rigidbody2D rb; 
   
    public GameObject playerExplosion; 
    


    // Start is called before the first frame update
    void Start(){
    
    

        levelScript = GameObject.FindObjectOfType<LevelScript>();
    }
    

    // Update is called once per frame
    void Update()
    {
        if (levelScript.currentTime <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        Instantiate(playerExplosion,transform.position,Quaternion.identity);
        Destroy(gameObject);

    }
}
