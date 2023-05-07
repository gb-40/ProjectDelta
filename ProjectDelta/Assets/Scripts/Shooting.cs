using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject pulseShotPrefab;
    public float bulletForce = 20f;

    public bool canTripleShot = false;
    public bool canPulseShot = false;

    IEnumerator PowerupDuration(bool powerup, float duration)
    {
        if (powerup)
        {
            yield return new WaitForSeconds(duration);
            
            if (powerup == canTripleShot)
            {
                canTripleShot = false;
            }
            else if (powerup == canPulseShot)
            {
                canPulseShot = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(canTripleShot)
            {
                tripleShot();
            }
            else if(canPulseShot)
            {
                pulseShot();
            }
            else
            {
                singleShot();
            }
        }
    }

    void singleShot() 
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    void tripleShot()
    {
        for(int i = -1; i < 2; i++) // repeat 3 times
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0f, 0f, i * 15f));
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>(); // get existing rigidbody component
            rb.AddForce(bullet.transform.up * bulletForce, ForceMode2D.Impulse);
        }
    }

    void pulseShot() 
    {
        GameObject pulseShot = Instantiate(pulseShotPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = pulseShot.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if(!canPulseShot && !canTripleShot)
        {
            if(collision.gameObject.name.Contains("TSpowerup"))
            {
                canTripleShot = true;
                StartCoroutine(PowerupDuration(canTripleShot, 5f));
                Destroy(collision.gameObject);
            }
            else if(collision.gameObject.name.Contains("PSpowerup"))
            {
                canPulseShot = true;
                StartCoroutine(PowerupDuration(canPulseShot, 5f));
                Destroy(collision.gameObject);
            }
        }
    }
}
