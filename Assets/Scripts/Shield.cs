using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

	public AudioSource[] shieldSfx;

	private SpriteRenderer sp;
	private bool isShieldActive = false;
	private float shieldActiveTime;
	private float timer = 0f;

	void Start () {
		sp = GetComponent<SpriteRenderer> ();
	}

	void Update () {
		
	}
		
	void DeactiveShield () {
		isShieldActive = false;

		sp.enabled = false;
		timer = 0f;
	}

	public void activateShield (float activePeriod){
		isShieldActive = true;
		sp.enabled = true;

		shieldActiveTime = activePeriod;
		shieldSfx [0].Play ();
	}
}
