using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

	public AudioSource collectedSfx;

	private SpriteRenderer sp;
	[HideInInspector]
	public bool gotCollected = false;

	private bool isDeadAlr = false;

	void Start() {
		GameEventManager.GameOver += Clear;
		GameEventManager.GameWin += Clear;

		sp = GetComponent<SpriteRenderer> ();
	}

	void Update() {
	//	if (gameObject && !isDeadAlr) {
			if (gotCollected && !collectedSfx.isPlaying) {
				Destroy (this.gameObject);
			}
		//}
	}

	public void collectPowerup(){
		gotCollected = true;

		sp.enabled = false;
		collectedSfx.Play ();
	}

	private void Clear(){
	//	if (gameObject && !isDeadAlr) {
			Destroy (this.gameObject);
	//	}
	}

	void OnDestroy() {
		GameEventManager.GameOver -= Clear;
		GameEventManager.GameWin -= Clear;
	}
}
