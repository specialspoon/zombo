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
    public Transform gunTransform;

    public float gunRot;
    public bool isMoving;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

        gunRot = gunTransform.eulerAngles.z;

        if (movement.x == 0 && movement.y == 0)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }

        animate();
        //Debug.Log(gunRot);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }


    void animate()
    {
        if (!isMoving)
        {
            if (gunRot > 170 && gunRot < 190)
            {
                Debug.Log("down");
            }
            if (gunRot > 190 && gunRot < 205)
            {
                Debug.Log("down-and-to-the-right-a-teeny-tiny-lil-bit");
            }
            if (gunRot > 205 && gunRot < 225)
            {
                Debug.Log("down-and-to-the-right-lil-bit");
            }
            if (gunRot > 225 && gunRot < 315)
            {
                Debug.Log("right");
            }
            if ((gunRot > 315 && gunRot < 360) || (gunRot > 0 && gunRot < 45))
            {
                Debug.Log("up");
            }
            if (gunRot > 45 && gunRot < 135)
            {
                Debug.Log("left");
            }
            if (gunRot > 135 && gunRot < 155)
            {
                Debug.Log("down-and-to-the-left-lil-bit");
            }
            if (gunRot > 155 && gunRot < 170)
            {
                Debug.Log("down-and-to-the-left-a-teeny-tiny-lil-bit");
            }
        }
        if (isMoving)
        {
            if (gunRot > 240 && gunRot < 315)
            {

            }
            if (gunRot > 120 && gunRot < 240)
            {
                animator.Play("player_walk_down");
            }
            if (gunRot > 30 && gunRot < 120)
            {
                animator.Play("player_walk_left");
            }
            if (gunRot > 315 || gunRot < 30)
            {
                animator.Play("player_walk_up");
            }
        }
    }
}
