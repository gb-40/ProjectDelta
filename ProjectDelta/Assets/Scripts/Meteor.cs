using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float range = 45f; 
    public float speed = 1f; 
    public int healh = 3;
    private Vector2 targetPosition;  
    // Start is called before the first frame update
    void Start()
    {
        targetPosition = GetRandomPosition(); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            targetPosition = GetRandomPosition();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Bullet"))
        {
            healh --;

            if (healh <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    Vector2 GetRandomPosition()
    {
        float x = Random.Range(-range, range);
        float y = Random.Range(-range, range); 

        return (Vector2)transform.position + new Vector2(x,y);
    }
}
