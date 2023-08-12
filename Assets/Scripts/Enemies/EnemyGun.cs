using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    // links to other components
    public Transform player;
    public Rigidbody2D rb;

    void Update()
    {
        // figure out direction towards player
        Vector2 lookDir = player.position - transform.position;
        lookDir = lookDir.normalized;

        // figure out angle towards player and rotate towards player
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.MoveRotation(angle);
    }
}
