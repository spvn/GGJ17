using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour {
	
	public float initialMovementDown = 1f;

	private bool move = false;
	private Vector3 startPos;
	private float timer = 0f;
	private float dist = 0f;

	void Awake() {
		GameEventManager.TitleScreen += Reset;
		GameEventManager.GameWin += Win;

		startPos = transform.position;
	}

	void Start () {
		
	}

	void Update () {
		if (move) {
			timer += Time.deltaTime;

			transform.position = startPos - new Vector3 (0f, dist, 0f);

			if (dist < initialMovementDown) {
				dist = timer * 2f;
			}
		}
	}

	void Win() {
		StartCoroutine (WaitAWhile ());
	}

	IEnumerator WaitAWhile(){
		yield return new WaitForSeconds (2f);
		timer = 0f;
		dist = 0f;
		move = true;
	}

	void Reset() {
		timer = 0f;
		dist = 0f;
		move = false;

		transform.position = startPos;
	}
}
