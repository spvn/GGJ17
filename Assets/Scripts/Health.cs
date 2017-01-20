using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public float maxHealth;
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
	}

	public virtual void reduceHealth(float amt){
		currentHealth -= amt;

		if (currentHealth < 0f) {
			currentHealth = 0f;
			isDead = true;
		}
	}

	public virtual void addHealth(float amt){
		currentHealth += amt;

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
