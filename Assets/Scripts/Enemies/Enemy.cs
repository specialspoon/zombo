using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 50;
    public float damage = 10;

    public Transform player;
    public Rigidbody2D rb;
    public Animator animator;

    void Start()
    {
        animator.SetTrigger("idle");
    }

    public void Update()
    {
        if (health <= 0f)
        {
            Destroy(gameObject);
        }

        animate();

        // 0 - 45 : 45-90 : 90 - 135 : 135 - 180 : 180 - 225 : 225 - 270 : 270 - 360 

    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            PlayerHealth health = collision.collider.GetComponent<PlayerHealth>();
            health.TakeDamage(damage);
        }
    }

    public void Damage(float damage)
    {
        health -= damage;
    }

    public void animate()
    {
        Vector2 lookDir = player.position - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

        if (angle < 0 && angle > -180)
        {
            animator.SetTrigger("right");
        }
        else
        {
            animator.SetTrigger("left");
        }
    }

}
