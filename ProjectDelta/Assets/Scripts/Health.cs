using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void takeDamage(int dmg)
    {
        currentHealth = currentHealth - dmg;

        if(currentHealth < 1)
        {
            Debug.Log("DEAD");
            Destroy(gameObject);
        }
    }
}
