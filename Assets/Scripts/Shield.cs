using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

	public Health playerHealth;
	public AudioSource[] shieldSfx;

	private SpriteRenderer sp;
	private bool isShieldActive = false;
	private float shieldActiveTime;

	void Start () {
		sp = GetComponent<SpriteRenderer> ();
	}

	public void deactiveShield () {
		isShieldActive = false;

		sp.enabled = false;
		shieldSfx [1].Play ();
	}

	public void activateShield (float activePeriod){
		isShieldActive = true;
		sp.enabled = true;
		playerHealth.shieldPlayer (activePeriod);

		shieldActiveTime = activePeriod;
		shieldSfx [0].Play ();
	}
}
