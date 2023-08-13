using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
	public Transform firePoint;
	public GameObject bulletPrefab;
	public Camera cam;
	public Rigidbody2D rb;

	Vector2 mousePos;

	public float bulletForce = 20f;
	public float fireRate = 0.5f;
	public int magazineSize;
	public float reloadSpeed;
	public int bulletCount = 5;
	public float spreadAngle = 15f;

	public bool canShoot = true;
	public bool needsToReload = false;
	public bool isReloading = false;

	public int bulletsLeft;


    private void Start()
    {
		bulletsLeft = magazineSize;
    }

    // Update is called once per frame
    void Update()
	{
        if (Input.GetMouseButtonDown(0))
		{
			Shoot();
		}

		mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
		Vector2 lookDir = mousePos - rb.position;
		float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
		rb.MoveRotation(angle);
		
	}

	void Shoot()
	{
		if (canShoot == true && !(bulletsLeft <= 0) && isReloading == false)
        {
			canShoot = false;

			for (int i = 0; i < bulletCount; i++)
            {
				float angle = spreadAngle * (i - (bulletCount - 1) / 2f);
				Quaternion bulletRotation = Quaternion.Euler(0, 0, angle) * transform.rotation;

				GameObject bullet = Instantiate(bulletPrefab, firePoint.position, bulletRotation);
				Bullet bulletScript = bullet.GetComponent<Bullet>();

				bulletScript.bulletDamage = 10f;
				Destroy(bullet, 5f);
				Transform bulletTransform = bullet.GetComponent<Transform>();
				Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
				CircleCollider2D collider = bullet.GetComponent<CircleCollider2D>();
				rb.AddForce(bulletTransform.up * bulletForce, ForceMode2D.Impulse);
				Invoke("EndCooldown", fireRate);

				if (firePoint.GetComponent<TouchingEnemyCheck>().isTouchingEnemy == true)
				{
					collider.isTrigger = true;
				}
			}

			bulletsLeft--;

		}
		else if (bulletsLeft <= 0 && isReloading == false)
        {
			isReloading = true;
			Invoke("Reload", reloadSpeed);
        }
	}

	void EndCooldown()
    {
		canShoot = true;
    }

	void Reload()
    {
		bulletsLeft = magazineSize;
		isReloading = false;
    }
}
