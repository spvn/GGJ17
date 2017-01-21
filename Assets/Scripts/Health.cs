using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public float startingSobriety;
	public float proportionPerHit = 0.25f;
	public static float currentMaxSobriety;

	public GameObject damage1;
	public GameObject damage2;
	public GameObject damage3;
	public GameObject explodeAnimation;

	[HideInInspector]
	public bool isDead = false;

	private bool hasTriggerGameOver = false;

	void Awake () {
		GameEventManager.TitleScreen += ResetHealth;
		GameEventManager.GameOver += Die;

		currentMaxSobriety = startingSobriety;
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
		currentMaxSobriety = startingSobriety;
		hasTriggerGameOver = false;

		damage1.SetActive (true);
		damage2.SetActive (false);
		damage3.SetActive (false);
		explodeAnimation.SetActive (false);
	}

	private void Die() {
		explodeAnimation.SetActive (true);
	}

	public virtual void reduceHealth(){
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
		Debug.Log (currentMaxSobriety / startingSobriety);
		return currentMaxSobriety / startingSobriety;
	}

	public float getCurrentHealth() {
		return currentMaxSobriety;
	}
}
