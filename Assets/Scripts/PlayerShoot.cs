using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

	public Transform leftShootingPosition;
	public Transform rightShootingPosition;

	public GameObject bulletPrefab;
	public float shootInterval;

	private bool allowShooting = true;
	private float shootTimer = 0f;

	void Awake () {
		GameEventManager.TitleScreen += StopShooting;
		GameEventManager.GameStart += StartShooting;
		GameEventManager.GameOver += StopShooting;
	}

	void Update () {
		if (allowShooting) {
			shootTimer += Time.deltaTime;

			if (shootTimer > shootInterval) {
				shootTimer = 0f;

				Shoot ();
			}
		}
	}

	private void StartShooting() {
		shootTimer = 0f;
		allowShooting = true;
	}

	private void StopShooting() {
		allowShooting = false;
	}


	void Shoot() {
		Instantiate (bulletPrefab, leftShootingPosition.position, Quaternion.identity);
		Instantiate (bulletPrefab, rightShootingPosition.position, Quaternion.identity);
	}
}
