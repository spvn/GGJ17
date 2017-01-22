using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooter : MonoBehaviour {

	public float missileShootInterval = 4f;
	public float bulletShootInterval = 2.4f;

	public GameObject bullet;
	public GameObject missile;

	private Vector3 startPos;
	private float missileShootTimer = 0f;
	private float bulletShootTimer = 0f;

	private Transform missilePoint1;//left shooter of boss
	private Transform missilePoint2;//right shooter of boss

	private Transform bulletPoint1;//left shooter of boss
	private Transform bulletPoint2;//right shooter of boss

	private float timeCount = 0f;

	// Use this for initialization
	void Start () {
		startPos = transform.position;

		missilePoint1 = transform.Find ("missilePoint1");
		missilePoint2 = transform.Find ("missilePoint2");

		bulletPoint1 = transform.Find ("bulletPoint1");
		bulletPoint2 = transform.Find ("bulletPoint2");
	}

	// Update is called once per frame
	void Update () {

		if (missileShootTimer > Random.Range (0.9f * missileShootInterval, 1.1f * missileShootInterval)) {
			missileShootTimer = 0f;
			StartCoroutine (shootMissile (1));
		} else {
			missileShootTimer += Time.deltaTime;
		}

		if (bulletShootTimer > Random.Range (0.9f * bulletShootInterval, 1.1f * bulletShootInterval)) {
			bulletShootTimer = 0f;
			StartCoroutine (shootBullet (2));
		} else {
			bulletShootTimer += Time.deltaTime;
		}
	}

	IEnumerator shootMissile(int num) {
		for (int i = 0; i < num; i++) {
			Instantiate (missile, missilePoint1.position, Quaternion.Euler(new Vector3(0f,0f, 180f)));
			Instantiate (missile, missilePoint2.position, Quaternion.Euler(new Vector3(0f,0f, 180f)));
			yield return new WaitForSeconds (0.1f);
		}
	}

	IEnumerator shootBullet(int num) {
		for (int i = 0; i < num; i++) {
			Instantiate (bullet, bulletPoint1.position, Quaternion.Euler(new Vector3(0f,0f, 180f)));
			Instantiate (bullet, bulletPoint2.position, Quaternion.Euler(new Vector3(0f,0f, 180f)));
			yield return new WaitForSeconds (0.1f);
		}
	}

}
