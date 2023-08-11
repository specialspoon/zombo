using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 50;
    public float damage = 10;

    public Transform player;
    public Rigidbody2D rb;
    public Animator animator;
    

    void Update()
    {
        if (health <= 0f)
        {
            Destroy(gameObject);
        }


        //Vector2 lookDir = player.position - transform.position;
        //float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        //rb.MoveRotation(angle);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            PlayerHealth health = collision.collider.GetComponent<PlayerHealth>();
            health.TakeDamage(damage);
        }
    }

    public void Damage(float damage)
    {
        health -= damage;
    }
}
