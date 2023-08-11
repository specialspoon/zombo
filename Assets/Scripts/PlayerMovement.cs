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
        var keys = Keyboard.current;
        var mouse = Mouse.current;
        var touch = Touchscreen.current;
        var gamepad = Gamepad.current;

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        Debug.Log(movement);
        if (movement.x > 0)
        {
            animator.SetTrigger("right");
            //Debug.Log("right");
        }
        if (movement.x < 0)
        {
            animator.SetTrigger("left");
            //Debug.Log("left");
        }
        if (movement.y < 0)
        {
            animator.SetTrigger("down");
            //Debug.Log("down");
        }
        if (movement.y > 0)
        {
            animator.SetTrigger("up");
            //Debug.Log("up");
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}
