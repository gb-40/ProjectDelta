using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public GameObject basicProjectilePrefab; // Prefab for basic attack projectile
    public GameObject spiralProjectilePrefab; // Prefab for spiral shot projectile
    public Transform bossFirePoint; // Transform representing the fire point of the boss
    public float basicAttackInterval = 0.5f; // Interval between basic attack projectiles
    public float spiralShotInterval = 0.5f; // Interval between spiral shot projectiles
    public float spiralShotRotationSpeed = 180f; // Speed at which spiral shot rotates (in degrees per second)
    public float projectileSpeed = 10f; // Speed at which the projectiles move

    private float attackTimer; // Timer for alternating between attacks
    private float spiralShotTimer; // Timer for spiral shot interval
    private bool isBasicAttack; // Flag indicating whether it's a basic attack

    // Start is called before the first frame update
    void Start()
    {
        attackTimer = 0f;
        spiralShotTimer = 0f;
        isBasicAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer += Time.deltaTime;
        spiralShotTimer += Time.deltaTime;

        if (attackTimer >= 5f)
        {
            // Alternate between basic attack and spiral attack
            isBasicAttack = !isBasicAttack;
            attackTimer = 0f;
        }

        if (isBasicAttack)
        {
            PerformBasicAttack();
        }
        else
        {
            PerformSpiralShot();
        }
    }

    // Perform the basic attack by shooting projectiles in 8 directions
    void PerformBasicAttack()
    {
        if (Time.time >= basicAttackInterval)
        {
            for (int i = 0; i < 8; i++)
            {
                float angle = i * 45f;
                Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                GameObject projectile = Instantiate(basicProjectilePrefab, bossFirePoint.position, rotation);
                projectile.GetComponent<Rigidbody2D>().velocity = projectile.transform.up * projectileSpeed;
            }

            basicAttackInterval += 0.5f;
        }
    }

    // Perform the spiral shot by shooting projectiles in a rotating pattern
    void PerformSpiralShot()
    {
        if (spiralShotTimer >= spiralShotInterval)
        {
            Quaternion rotation = Quaternion.Euler(0f, 0f, spiralShotRotationSpeed * Time.time);
            GameObject projectile = Instantiate(spiralProjectilePrefab, bossFirePoint.position, rotation);
            projectile.GetComponent<Rigidbody2D>().velocity = projectile.transform.up * projectileSpeed;

            spiralShotTimer = 0f;
        }
    }
}