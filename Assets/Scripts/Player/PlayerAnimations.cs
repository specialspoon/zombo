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
    public Sprite down;
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
            if (gunRot > 170 && gunRot < 190)
            {
                Debug.Log("down");
                playerSprite.sprite = down;
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
                Debug.Log("right");
                playerSprite.sprite = right;
                playerSprite.flipX = false;
                gunSprite.sortingOrder = 1;
            }
            if ((gunRot > 315 && gunRot < 360) || (gunRot > 0 && gunRot < 45))
            {
                Debug.Log("up");
                playerSprite.sprite = up;
                playerSprite.flipX = false;
                gunSprite.sortingOrder = -1;
            }
            if (gunRot > 45 && gunRot < 135)
            {
                Debug.Log("left");
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
