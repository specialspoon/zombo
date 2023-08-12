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
        if (movement.y < 0)
        {
            animator.Play("player_walk_down");
            //animator.SetTrigger("down");
            //Debug.Log("down");
        }
        if (movement.y > 0)
        {
            animator.Play("player_walk_up");
            //animator.SetTrigger("up");
            //Debug.Log("up");
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}
