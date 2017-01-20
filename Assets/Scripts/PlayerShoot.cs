using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

	public Transform leftShootingPosition;
	public Transform rightShootingPosition;

	public GameObject bulletPrefab;
	public float shootInterval;

	private float shootTimer = 0f;

	void Start () {
		
	}
	

	void Update () {
		shootTimer += Time.deltaTime;

		if (shootTimer > shootInterval) {
			shootTimer = 0f;

			Shoot ();
		}
	}

	void Shoot() {
		Instantiate (bulletPrefab, leftShootingPosition.position, Quaternion.identity);
		Instantiate (bulletPrefab, rightShootingPosition.position, Quaternion.identity);
	}
}
