using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    private int currentHealth;
    
    public Image healthbar;

    void Start()
    {
        
      
    }

    void Update()
    {
         GameObject boss = GameObject.FindGameObjectWithTag("Boss");
         if(boss != null)
        {
            Debug.Log("Found BOss");
          currentHealth =  boss.GetComponent<Health>().currentHealth;
          healthbar.fillAmount = currentHealth /200f; 
            
        }
    }
    
}
