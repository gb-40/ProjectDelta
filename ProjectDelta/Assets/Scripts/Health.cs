using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
       // anim = gameObject.GetComponent<Animator>();
    }

    public void takeDamage(int dmg)
    {
        currentHealth = currentHealth - dmg;
 
    }
}
