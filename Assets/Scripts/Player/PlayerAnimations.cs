using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{

    public Transform gunTransform;
    public SpriteRenderer gunSprite;

    public Animator animator;

    public float gunRot;
    public bool isMoving;


    private void Start()
    {
        SpriteRenderer playerSprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        gunRot = gunTransform.eulerAngles.z;

        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }

        if (gunRot < 180)
        {
            gunSprite.flipY = true;
        }

        else
        {
            gunSprite.flipY = false;
        }

        if (!isMoving)
        {
            if (gunRot > 170 && gunRot < 190)
            {
                animator.Play("player_look_down");
                gunSprite.sortingOrder = 1;
            }
            if (gunRot > 190 && gunRot < 205)
            {
                animator.Play("player_look_down_right");
                gunSprite.sortingOrder = 1;
            }
            if (gunRot > 205 && gunRot < 225)
            {
                animator.Play("player_look_down_right_more");
                gunSprite.sortingOrder = 1;
            }

            if (gunRot > 225 && gunRot < 315)
            {
                animator.Play("player_look_right");
                gunSprite.sortingOrder = 1;
            }
            if ((gunRot > 315 && gunRot < 360) || (gunRot > 0 && gunRot < 45))
            {
                animator.Play("player_look_up");
                gunSprite.sortingOrder = -1;
            }
            if (gunRot > 45 && gunRot < 135)
            {
                animator.Play("player_look_left");
                gunSprite.sortingOrder = 1;
            }
            if (gunRot > 135 && gunRot < 155)
            {
                animator.Play("player_look_down_left_more");
                gunSprite.sortingOrder = 1;
            }
            if (gunRot > 155 && gunRot < 170)
            {
                animator.Play("player_look_down_left");
                gunSprite.sortingOrder = 1;
            }
        }
        if (isMoving)
        {
            if (gunRot > 170 && gunRot < 190)
            {
                animator.Play("player_walk_down");
                gunSprite.sortingOrder = 1;
            }
            if (gunRot > 190 && gunRot < 205)
            {
                animator.Play("player_walk_down_right");
                gunSprite.sortingOrder = 1;
            }
            if (gunRot > 205 && gunRot < 225)
            {
                animator.Play("player_walk_down_right_more");
                gunSprite.sortingOrder = 1;
            }

            if (gunRot > 225 && gunRot < 315)
            {
                animator.Play("player_walk_right");
                gunSprite.sortingOrder = 1;
            }
            if ((gunRot > 315 && gunRot < 360) || (gunRot > 0 && gunRot < 45))
            {
                animator.Play("player_walk_up");
                gunSprite.sortingOrder = -1;
            }
            if (gunRot > 45 && gunRot < 135)
            {
                animator.Play("player_walk_left");
                gunSprite.sortingOrder = 1;
            }
            if (gunRot > 135 && gunRot < 155)
            {
                animator.Play("player_walk_down_left_more");
                gunSprite.sortingOrder = 1;
            }
            if (gunRot > 155 && gunRot < 170)
            {
                animator.Play("player_walk_down_left");
                gunSprite.sortingOrder = 1;
            }
        }
    }
}
