using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{ private Health health; 

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponentInChildren<Health>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
