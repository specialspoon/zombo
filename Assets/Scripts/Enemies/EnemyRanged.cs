using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanged : MonoBehaviour
{
    // stats
    public float health = 50;
    public float damage = 10;
    public float fireSpeed;
    public float range;

    // links to other components
    public Transform player;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Rigidbody2D rb;
    public LayerMask playerLayer;
    public LayerMask wallLayer;
    public FollowTarget followTarget;

    // variables used in the code
    [SerializeField] private bool canShoot;
    [SerializeField] private bool canSeePlayer;

    // start function
    private void Start()
    {
        canShoot = true;
    }

    void Update()
    {
        // make sure enemies die when they have 0 health (kinda obvious)
        if (health <= 0f)
        {
            Destroy(gameObject);
        }

        // figure out direction towards player
        Vector2 lookDir = player.position - transform.position;
        lookDir = lookDir.normalized;

        // figure out if there is anything in the way of the line of sight
        if (Physics2D.Raycast(firePoint.position, new Vector2(lookDir.x, lookDir.y), range, playerLayer) && !Physics2D.Raycast(firePoint.position, new Vector2(lookDir.x, lookDir.y), range, wallLayer))
        {
            canSeePlayer = true;
            followTarget.isStopped = true;
        }
        else
        {
            canSeePlayer = false;
            followTarget.isStopped = false;
        }

        // shooting script
        if (canShoot == true && canSeePlayer == true)
        {
            canShoot = false;

            GameObject bullet;
            bullet = Instantiate(bulletPrefab, new Vector3(firePoint.position.x, firePoint.position.y, 0), Quaternion.identity);

            Bullet bulletScript = bullet.GetComponent<Bullet>();
            bulletScript.bulletDamage = 10f;

            Destroy(bullet, 5f);

            Rigidbody2D rb;
            rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(lookDir.x * fireSpeed, lookDir.y * fireSpeed), ForceMode2D.Impulse);

            Invoke("Reload", 0.5f);
        }
    }

    // function to take damage
    public void Damage(float damage)
    {
        health -= damage;
    }

    // function to reload
    public void Reload()
    {
        canShoot = true;
    }
}
