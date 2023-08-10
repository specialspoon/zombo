using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletDamage;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("enemy hit");
            Enemy enemyScript;
            enemyScript = collision.gameObject.GetComponent<Enemy>();
            enemyScript.Damage(bulletDamage);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("EnemyRanged"))
        {
            Debug.Log("enemy hit");
            EnemyRanged enemyScript;
            enemyScript = collision.gameObject.GetComponent<EnemyRanged>();
            enemyScript.Damage(bulletDamage);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("enemy hit");
            PlayerHealth healthScript;
            healthScript = collision.gameObject.GetComponent<PlayerHealth>();
            healthScript.TakeDamage(bulletDamage);
            Destroy(gameObject);
        }

        Destroy(gameObject);
    }

    
}
