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
    public SpriteRenderer gunSprite;

    public float gunRot;
    public bool isMoving = false;

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

        Debug.Log(movement.x != 0 || movement.y != 0);
        Animate();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    public void Animate()
    {
 

        if (!isMoving)
        {
            if (gunRot > 240 && gunRot < 315)
            {
                //animator.Play("player_look_right");
                gunSprite.flipX = false;
                gunSprite.sortingOrder = 1;
            }
            if (gunRot > 120 && gunRot < 240)
            {
                //animator.Play("player_look_down");
                gunSprite.sortingOrder = 1;
            }
            if (gunRot > 30 && gunRot < 120)
            {
                //animator.Play("player_look_left");
                gunSprite.sortingOrder = 1;
                gunSprite.flipX = true;
            }
            if (gunRot > 315 || gunRot < 30)
            {
                //animator.Play("player_look_up");
                gunSprite.sortingOrder = -1;
            }
        }

        if (isMoving)
        {
            if (gunRot > 240 && gunRot < 315)
            {
                animator.Play("player_walk_right");
                gunSprite.flipX = false;
                gunSprite.sortingOrder = 1;
            }
            if (gunRot > 120 && gunRot < 240)
            {
                animator.Play("player_walk_down");
                gunSprite.sortingOrder = 1;
            }
            if (gunRot > 30 && gunRot < 120)
            {
                animator.Play("player_walk_left");
                gunSprite.sortingOrder = 1;
                gunSprite.flipX = true;
            }
            if (gunRot > 315 || gunRot < 30)
            {
                animator.Play("player_walk_up");
                gunSprite.sortingOrder = -1;
            }
        }
    }
}
