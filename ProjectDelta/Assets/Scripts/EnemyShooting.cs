using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public float startInterval = 1f;
    public float shotInterval;
    private bool isOnScreen = false;

    // Start is called before the first frame update
    void Start()
    {
        startInterval = Random.Range(1f, 2.5f);
        shotInterval = startInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnScreen && shotInterval <= 0)
        {
            if (CanShoot())
            {
                enemyShoot();
                Debug.Log("ENEMY SHOT");
            }
            
            shotInterval = startInterval;
        }
        else
        {
            shotInterval -= Time.deltaTime;
        }
    }

    private void OnBecameVisible()
    {
        isOnScreen = true;
    }

    private void OnBecameInvisible()
    {
        isOnScreen = false;
    }

    bool CanShoot()
    {
        Vector2 direction = firePoint.up;
        RaycastHit2D hit = Physics2D.Raycast(firePoint.position, direction);

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Player"))
            {
                return true;
            }
            else if (hit.collider.CompareTag("walls"))
            {
                return false;
            }
        }

        return false;
    }

    void enemyShoot() 
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
