using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerup : MonoBehaviour
{
    public float speedBoost;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerMovement movementScript;
            movementScript = collision.gameObject.GetComponent<PlayerMovement>();
            movementScript.moveSpeed += speedBoost;
            Destroy(gameObject);
        }
    }
}
