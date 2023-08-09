using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 50;

    public Transform player;
    public Rigidbody2D rb;
    
    void Update()
    {
        if (health <= 0f)
        {
            Destroy(gameObject);
        }

        Vector2 lookDir = player.position - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.MoveRotation(angle);
    }

    public void Damage(float damage)
    {
        health -= damage;
    }
}
