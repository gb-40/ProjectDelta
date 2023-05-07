using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Death()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     IEnumerator Death()
    {
        // Wait for the death animation to finish
        yield return new WaitForSeconds(2f);


        // Destroy the game object
        Destroy(gameObject);
    }
}
