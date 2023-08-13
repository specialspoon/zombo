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

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x > 0)
        {
            animator.Play("player_walk_right");
            //animator.SetTrigger("right");
            //Debug.Log("right");
        }
        if (movement.x < 0)
        {
            animator.Play("player_walk_left");
            //animator.SetTrigger("left");
            //Debug.Log("left");
        }
        //not moving
        if (movement.x == 0)
        {
            var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector2 lookDir = mousePos - transform.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

            if (angle < -180)
            {
                animator.Play("player_look_left");
            }
            else
            {
                animator.Play("player_look_right");
            }
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}
