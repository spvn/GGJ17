using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

	public float shootBoostTime = 2f;
	public Transform leftShootingPosition;
	public Transform rightShootingPosition;

	public GameObject bulletPrefab;
	public float shootInterval;
	public float boostedShootInterval;

	private bool isBoosted = false;
	private float originalShootInterval;
	private bool allowShooting = true;
	private float shootTimer = 0f;
	private float shootBoostTimer = 0f;

	void Awake () {
		GameEventManager.TitleScreen += StopShooting;
		GameEventManager.GameStart += StartShooting;
		GameEventManager.GameOver += StopShooting;
		GameEventManager.GameWin += StopShooting;

		originalShootInterval = shootInterval;
	}

	void Update () {
		if (allowShooting) {
			shootTimer += Time.deltaTime;

			if (isBoosted) {
				shootBoostTimer += Time.deltaTime;

				if (shootBoostTimer > shootBoostTime) {
					shootBoostTimer = 0f;
					isBoosted = false;
					shootInterval = originalShootInterval;
				}
			}

			if (shootTimer > shootInterval) {
				shootTimer = 0f;

				Shoot ();
			}
		}
	}

	private void StartShooting() {
		shootTimer = 0f;
		shootBoostTimer = 0f;
		allowShooting = true;
		isBoosted = false;
	}

	private void StopShooting() {
		allowShooting = false;
	}
		
	void Shoot() {
		Instantiate (bulletPrefab, leftShootingPosition.position, Quaternion.identity);
		Instantiate (bulletPrefab, rightShootingPosition.position, Quaternion.identity);
	}

	public void boostShooting(){
		shootInterval = boostedShootInterval;
		isBoosted = true;
		shootBoostTimer = 0f;
	}
}
