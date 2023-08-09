using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{ 

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("enemy hit");
            Enemy enemyScript;
            enemyScript = collision.gameObject.GetComponent<Enemy>();
            enemyScript.Damage(10f);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("EnemyRanged"))
        {
            Debug.Log("enemy hit");
            EnemyRanged enemyScript;
            enemyScript = collision.gameObject.GetComponent<EnemyRanged>();
            enemyScript.Damage(10f);
            Destroy(gameObject);
        }

        Destroy(gameObject);
    }

    
}
