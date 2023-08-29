using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRatePowerup : MonoBehaviour
{
    public float fireRateBoost;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerShooting shootingScript;
            shootingScript = collision.gameObject.GetComponentInChildren<PlayerShooting>();
            shootingScript.shotsPerSec += fireRateBoost;
            
            Destroy(gameObject);
        }
    }
}
