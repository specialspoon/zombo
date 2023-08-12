using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingEnemyCheck : MonoBehaviour
{
    public bool isTouchingSomething = false;
    public bool isTouchingEnemy = false;

    private void OnTriggerStay2D(Collider2D collider)
    {
        isTouchingSomething = true;

        if(collider.CompareTag("Enemy") || collider.CompareTag("EnemyRanged"))
        {
            isTouchingEnemy = true;
        }

        else
        {
            isTouchingEnemy = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isTouchingSomething = false;
    }

    void Update()
    {
        if(isTouchingSomething == false)
        {
            isTouchingEnemy = false;
        }
    }
}
