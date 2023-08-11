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

	public bool canShoot = true;

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
		if (canShoot == true)
        {
			canShoot = false;
			GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
			Bullet bulletScript = bullet.GetComponent<Bullet>();
			bulletScript.bulletDamage = 10f;
			Destroy(bullet, 5f);
			Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
			rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
			Invoke("Reload", fireRate);
		}
	}

	void Reload()
    {
		canShoot = true;
    }
}
