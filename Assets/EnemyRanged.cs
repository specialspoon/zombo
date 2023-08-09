using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanged : MonoBehaviour
{
    public float health = 50;
    public float fireSpeed;

    public Transform player;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Rigidbody2D rb;

    [SerializeField] private bool canShoot;

    Vector2 direction;

    private void Start()
    {
        canShoot = true;
    }

    void Update()
    {
        if (health <= 0f)
        {
            Destroy(gameObject);
        }

        direction = player.position - transform.position;
        direction = direction.normalized;

        if (canShoot == true)
        {
            canShoot = false;
            GameObject bullet;
            bullet = Instantiate(bulletPrefab, new Vector3(firePoint.position.x, firePoint.position.y, 0), Quaternion.identity);
            Rigidbody2D rb;
            rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(direction.x * fireSpeed, direction.y * fireSpeed), ForceMode2D.Impulse);
            Invoke("Reload", 0.5f);
        }


        Vector2 lookDir = player.position - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.MoveRotation(angle);
    }

    public void Damage(float damage)
    {
        health -= damage;
    }

    public void Reload()
    {
        canShoot = true;
    }
}
