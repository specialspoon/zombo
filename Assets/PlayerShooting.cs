using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	public Transform firePoint;
	public GameObject bulletPrefab;
	public Rigidbody2D playerRb;

	public float bulletForce = 20f;
	public float shotCooldown = 0.5f;
	public float recoilForce = 10f;

	public bool canShoot = true;

	void FixedUpdate()
	{
		if (Input.GetButton("Fire1"))
		{
			Shoot();
			
		}
	}

	void Shoot()
	{
		if (canShoot == true)
        {
			GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
			Destroy(bullet, 5f);
			Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
			rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
			playerRb.AddForce(firePoint.up * -1000);

			canShoot = false;
			Invoke("EndShotCooldown", shotCooldown);
		}

		
	}

	void EndShotCooldown()
    {
		canShoot = true;
    }

    public void ResetFirerate()
    {
		shotCooldown = 0.5f;
    }
}
