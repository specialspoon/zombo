using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100;

    public bool isDead = false;
    public bool canTakeDamage = true;

    public void TakeDamage(float damage)
    {
        if(canTakeDamage == true)
        {
            canTakeDamage = false;
            health -= damage;
            if (health <= 0f)
            {
                Die();
            }
            Invoke("EndInvincibility", 0.5f);
        }
    }

    public void Die()
    {
        isDead = true;
    }

    public void EndInvincibility()
    {
        canTakeDamage = true;
    }
}
