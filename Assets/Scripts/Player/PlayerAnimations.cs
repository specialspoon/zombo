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

    public Sprite up;
    public Sprite right;
    public Sprite downs;
    public Sprite downRightLittle;
    public Sprite downRight;

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

        SpriteRenderer playerSprite = GetComponent<SpriteRenderer>();

        if (!isMoving)
        {
            animator.StopPlayback();
            if (gunRot > 170 && gunRot < 190)
            {
                Debug.Log("down not moving");
                playerSprite.sprite = downs;
                playerSprite.flipX = false;
                gunSprite.sortingOrder = 1;
            }
            if (gunRot > 190 && gunRot < 205)
            {
                playerSprite.sprite = downRightLittle;
                playerSprite.flipX = false;
            }
            if (gunRot > 205 && gunRot < 225)
            {
                playerSprite.sprite = downRight;
                playerSprite.flipX = false;
                gunSprite.sortingOrder = 1;
                gunSprite.flipX = false;
            }

            if (gunRot > 225 && gunRot < 315)
            {
                playerSprite.sprite = right;
                playerSprite.flipX = false;
                gunSprite.sortingOrder = 1;
            }
            if ((gunRot > 315 && gunRot < 360) || (gunRot > 0 && gunRot < 45))
            {
                playerSprite.sprite = up;
                playerSprite.flipX = false;
                gunSprite.sortingOrder = 0;
            }
            if (gunRot > 45 && gunRot < 135)
            {
                playerSprite.sprite = right;
                playerSprite.flipX = true;
                gunSprite.sortingOrder = 1;
            }
            if (gunRot > 135 && gunRot < 155)
            {
                playerSprite.sprite = downRight;
                playerSprite.flipX = true;
                gunSprite.sortingOrder = 1;
                gunSprite.flipX = true;
            }
            if (gunRot > 155 && gunRot < 170)
            {
                playerSprite.sprite = downRightLittle;
                playerSprite.flipX = true;
            }
        }
        if (isMoving)
        {
            if (gunRot > 170 && gunRot < 190)
            {
                animator.Play("player_walk_down");
                playerSprite.flipX = false;
                gunSprite.sortingOrder = 1;
            }
            if (gunRot > 190 && gunRot < 205)
            {
                animator.Play("player_walk_down_right_more");
                playerSprite.flipX = false;
            }
            if (gunRot > 205 && gunRot < 225)
            {
                animator.Play("player_walk_down_right");
                playerSprite.flipX = false;
                gunSprite.sortingOrder = 1;
                gunSprite.flipX = false;
            }

            if (gunRot > 225 && gunRot < 315)
            {
                animator.Play("player_walk_right");
                playerSprite.flipX = false;
                gunSprite.sortingOrder = 1;
            }
            if ((gunRot > 315 && gunRot < 360) || (gunRot > 0 && gunRot < 45))
            {
                animator.Play("player_walk_up");
                playerSprite.flipX = false;
                gunSprite.sortingOrder = 0;
            }
            if (gunRot > 45 && gunRot < 135)
            {
                animator.Play("player_walk_left");
                playerSprite.flipX = true;
                gunSprite.sortingOrder = 1;
            }
            if (gunRot > 135 && gunRot < 155)
            {
                animator.Play("player_walk_down_right");
                playerSprite.flipX = true;
                gunSprite.sortingOrder = 1;
                gunSprite.flipX = true;
            }
            if (gunRot > 155 && gunRot < 170)
            {
                animator.Play("player_walk_down_left_more");
                playerSprite.flipX = true;
            }
        }
    }
}
