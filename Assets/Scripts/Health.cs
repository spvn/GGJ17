using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public float maxHealth;

	public GameObject damage1;
	public GameObject damage2;
	public GameObject damage3;

	[HideInInspector]
	public bool isDead = false;

	protected float currentHealth;
	private bool hasTriggerGameOver = false;

	void Awake () {
		GameEventManager.GameStart += ResetHealth;
	}

	void Start() {
		ResetHealth ();
	}

	void Update () {
		if (isDead && !hasTriggerGameOver) {
			hasTriggerGameOver = true;
			GameEventManager.TriggerGameOver ();
		}
	}

	private void ResetHealth() {
		currentHealth = maxHealth;
		hasTriggerGameOver = false;

		damage1.SetActive (true);
		damage2.SetActive (false);
		damage3.SetActive (false);
	}

	public virtual void reduceHealth(float amt){
		currentHealth -= amt;

		if (!damage2.activeSelf) {
			damage2.SetActive (true);
		} else {
			damage3.SetActive (true);
		}

		if (currentHealth < 0f) {
			currentHealth = 0f;
			isDead = true;
		}
	}

	public virtual void addHealth(float amt){
		currentHealth += amt;

		if (damage3.activeSelf) {
			damage3.SetActive (false);
		} else {
			damage2.SetActive (false);
		}

		if (currentHealth > maxHealth) {
			currentHealth = maxHealth;
		}
	}

	public float getHealthProportion() {
		return currentHealth / maxHealth;
	}

	public float getCurrentHealth() {
		return currentHealth;
	}
}
