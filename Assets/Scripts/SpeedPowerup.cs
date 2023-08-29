using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerup : MonoBehaviour
{
    public float speedBoost;
    public float powerupTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerMovement movementScript;
            movementScript = collision.gameObject.GetComponent<PlayerMovement>();
            movementScript.moveSpeed += speedBoost;
            IEnumerator coroutine = movementScript.EndSpeedPowerup(speedBoost, powerupTime);
            movementScript.StartCoroutine(coroutine);
            Destroy(gameObject);
        }
    }
}
