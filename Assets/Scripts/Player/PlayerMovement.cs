using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSmoothing = 30f;

    public Animator animator;
    public Rigidbody2D rb;
    public Camera cam;
    public SpriteRenderer gunSprite;

    public float gunRot;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

        gunRot = angle;
        Debug.Log(angle);
        if (gunRot > -60 && gunRot < -120)
        {
            animator.Play("player_walk_right");
        }
        if (gunRot > -120 && gunRot < -240){
            animator.Play("player_walk_down");
        }
        if (gunRot > -240 && gunRot < -300)
        {
            animator.Play("player_walk_left");
        }
        if (gunRot > -300)
        {
            animator.Play("player_walk_up");
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}
