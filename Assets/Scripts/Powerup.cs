using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

	public AudioSource collectedSfx;

	private SpriteRenderer sp;
	[HideInInspector]
	public bool gotCollected = false;

	void Start() {
		GameEventManager.GameOver += Clear;
		GameEventManager.GameWin += Clear;

		sp = GetComponent<SpriteRenderer> ();
	}

	void Update() {
		if (gotCollected && !collectedSfx.isPlaying) {
			if (gameObject) {
				Destroy (gameObject);
			}
		}
	}

	public void collectPowerup(){
		gotCollected = true;

		sp.enabled = false;
		collectedSfx.Play ();
	}

	private void Clear(){
		if (gameObject) {
	//		Destroy (gameObject);
		}
	}
}
