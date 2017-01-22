using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

	public AudioSource collectedSfx;

	private SpriteRenderer sp;
	[HideInInspector]
	public bool gotCollected = false;
	public float movementRange = 1f;
	public float movementTime = 1f;
	public float lifeTime = 10f;
	private bool isDeadAlr = false;
	private bool reachedPos = true;
	private float lifeTimer = 0f;

	void Start() {
		GameEventManager.GameOver += Clear;
		GameEventManager.GameWin += Clear;

		sp = GetComponent<SpriteRenderer> ();
	}

	void Update() {

		if (reachedPos) {
			Vector3 movementVector = new Vector3 (Random.Range (-movementRange, movementRange), Random.Range (-movementRange, 0f), 0f);
			Vector3 finalPos = movementVector + transform.position;
			if (isWithinView (finalPos)) {
				reachedPos = false;
				StartCoroutine (moveToPos (transform.position, transform.position + movementVector, movementTime));
			}

		}

	//	if (gameObject && !isDeadAlr) {
			if (gotCollected && !collectedSfx.isPlaying) {
				Destroy (this.gameObject);
			}
			
		//}

		if (lifeTimer > lifeTime) {
			Destroy (this.gameObject);
		} else {
			lifeTimer += Time.deltaTime;
		}
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

	private bool isWithinView (Vector3 pos) {
		Vector3 viewportPoint = Camera.main.WorldToViewportPoint (pos);
		//Debug.Log (viewportPoint);
		if (viewportPoint.z > 0 && (new Rect (0.1f, -0.5f, 0.8f, 1.5f)).Contains (viewportPoint)) {
			return true;
		} else {
			return false;
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
	}
}
