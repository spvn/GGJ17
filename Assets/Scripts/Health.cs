﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public float invulnerabilityPeriod = 1f;
	public float startingSobriety;
	public float proportionPerHit = 0.25f;
	public static float currentMaxSobriety;

	[HideInInspector]
	public bool isInvulnerable = false;

	public Shield shield;
	public Renderer renderer;
	public GameObject damage1;
	public GameObject damage2;
	public GameObject damage3;
	public GameObject explodeAnimation; 

	[HideInInspector]
	public bool isDead = false;

	private bool hasTriggerGameOver = false;
	private float maxInvulnerableTime;
	private float timer = 0f;
	private Color32 redColor;

	void Awake () {
		GameEventManager.TitleScreen += ResetHealth;
		GameEventManager.GameOver += Die;
		GameEventManager.GameWin += Win;

		currentMaxSobriety = startingSobriety;
		redColor = new Color32 (255, 99, 99, 255);
	}

	void Start() {
		ResetHealth ();
	}

	void Update () {
		if (isDead && !hasTriggerGameOver) {
			hasTriggerGameOver = true;
			GameEventManager.TriggerGameOver ();
		}

		if (isInvulnerable) {
			timer += Time.deltaTime;
			if (timer > maxInvulnerableTime) {
				timer = 0f;
				isInvulnerable = false;
				shield.deactiveShield ();
			}
		}
	}

	IEnumerator GetHitFlash() {
		float t = 0f;
		while (t < invulnerabilityPeriod) {
			if (renderer.material.color == Color.white) {
				renderer.material.SetColor ("_Color", redColor);
			} else {
				renderer.material.SetColor ("_Color", Color.white);
			}
			t += Time.deltaTime;
			yield return null;
		}
		renderer.material.SetColor ("_Color", Color.white);
	}

	private void ResetHealth() {
		currentMaxSobriety = startingSobriety;
		isDead = false;
		hasTriggerGameOver = false;
		isInvulnerable = false;

		damage1.SetActive (true);
		damage2.SetActive (false);
		damage3.SetActive (false);
		explodeAnimation.SetActive (false);
	}

	private void Win(){
		isInvulnerable = true;
	}

	private void Die() {
		explodeAnimation.SetActive (true);
		GetComponent<AudioSource> ().Play ();
		currentMaxSobriety = startingSobriety;
	}

	public virtual void reduceHealth(){
		isInvulnerable = true;
		maxInvulnerableTime = invulnerabilityPeriod;

		currentMaxSobriety -= proportionPerHit * startingSobriety;

		if (!damage2.activeSelf) {
			damage2.SetActive (true);
		} else {
			damage3.SetActive (true);
		}

		if (currentMaxSobriety <= 0f) {
			currentMaxSobriety = 0f;
			isDead = true;
		}

		StartCoroutine (GetHitFlash ());
	}

	public virtual void addHealth(){
		currentMaxSobriety += proportionPerHit * startingSobriety;

		if (damage3.activeSelf) {
			damage3.SetActive (false);
		} else {
			damage2.SetActive (false);
		}

		if (currentMaxSobriety > startingSobriety) {
			currentMaxSobriety = startingSobriety;
		}
	}

	public float getHealthProportion() {
//		Debug.Log (currentMaxSobriety / startingSobriety);
		return currentMaxSobriety / startingSobriety;
	}

	public float getCurrentHealth() {
		return currentMaxSobriety;
	}

	public void shieldPlayer(float period){
		isInvulnerable = true;
		maxInvulnerableTime = period;
	}
}
