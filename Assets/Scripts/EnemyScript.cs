﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	public float shootInterval = 3f;
	public float initialMovementTime = 1f;
	public float movementRange = 0.1f;
	public float hoveringSpeed = 1f;
	public float difficultyModifier = 1f;

	public GameObject bullet;

	public GameObject[] powerups;

	private Vector3 targetPosition;
	private Vector3 origPos;
	private bool reachedPos = false;
	private float shootTimer = 0f;
	private Transform shootPoint;
	private AudioSource sfx;
	private bool sfxPlayed = false;

	// Use this for initialization
	void Start () {
		targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0,Camera.main.pixelWidth), Random.Range(Camera.main.pixelHeight/2f, Camera.main.pixelHeight), Camera.main.nearClipPlane));
		targetPosition = new Vector3 (targetPosition.x, targetPosition.y, 0f);
		origPos = transform.position;

		sfx = GetComponent<AudioSource> ();
		LerpVolume ();
		shootPoint = transform.Find ("shootPoint");
		//Debug.Log (origPos + " " + targetPosition);
		StartCoroutine (moveToPos(origPos, targetPosition, initialMovementTime));
	}
	
	// Update is called once per frame
	void Update () {

		if (reachedPos) {
			Vector3 movementVector = new Vector3 (Random.Range (-movementRange, movementRange), Random.Range (-movementRange, movementRange), 0f);
			Vector3 finalPos = movementVector + transform.position;
			if (isWithinView (finalPos)) {
				reachedPos = false;
				StartCoroutine (moveToPos (transform.position, transform.position + movementVector, hoveringSpeed));
			}

		}

		if (shootTimer > Random.Range (0.9f * shootInterval, 1.1f * shootInterval)) {
			shootTimer = 0f;
			StartCoroutine (shoot (3));
		} else {
			shootTimer += Time.deltaTime;
		}
	}

	IEnumerator moveToPos(Vector3 initialPos, Vector3 targetPosition, float time) {
		float duration = 0f;

		while (duration < time) {
			transform.position = Vector3.Slerp (initialPos, targetPosition, duration / time);
			duration += Time.deltaTime;
			yield return null;
		}

		reachedPos = true;
		sfx.Stop ();
	}
				
	IEnumerator shoot(int num) {
		for (int i = 0; i < num; i++) {
			Instantiate (bullet, shootPoint.position, Quaternion.Euler(new Vector3(0f,0f, 180f)));
			yield return new WaitForSeconds (0.1f);
		}
	}

	private bool isWithinView (Vector3 pos) {
		Vector3 viewportPoint = Camera.main.WorldToViewportPoint (pos);
		//Debug.Log (viewportPoint);
		if (viewportPoint.z > 0 && (new Rect (0.1f, 0.5f, 0.8f, 0.4f)).Contains (viewportPoint)) {
			return true;
		} else {
			return false;
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "PlayerBullet") {
			ObstacleManager.enemyCount--;
			Destroy (col.gameObject);
			Destroy (gameObject);

			ObstacleManager.addDifficulty (difficultyModifier);
		}
	}

	void LerpVolume() {
		sfx.volume = 0f;

		float duration = 0f;
		float totalLerpTime = 0.5f;

		while (duration < totalLerpTime) {
			sfx.volume = Mathf.Lerp (0f, 0.3f, duration / totalLerpTime);
			duration += Time.deltaTime;
		}

	}

	void OnDestroy() {
		if (Random.Range (0f, 1f) < 0.5f) {
			Instantiate (powerups [Random.Range (0, powerups.Length)], transform.position, Quaternion.identity);
		}
	}
}
