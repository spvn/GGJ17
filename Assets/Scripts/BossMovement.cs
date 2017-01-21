using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour {

	public float initialMovementDown = 1f;
	public float xAxisSpeed = 5f;
	public float maxX = 1.5f; 

	private bool move = true;
	private Vector3 startPos;
	private float timer = 0f;
	private float dist = 0f;

	void Awake() {
		GameEventManager.TitleScreen += Clear;
		//GameEventManager.GameStart += Reset;
		//GameEventManager.GameOver += Stop;
		GameEventManager.GameWin += Stop;
	}

	void Start () {
		startPos = transform.position;
	}

	void Update () {
		if (move) {
			timer += Time.deltaTime;

			transform.position = startPos + new Vector3 (maxX * Mathf.Sin (xAxisSpeed * timer), 0f, 0f)
			- new Vector3 (0f, dist, 0f);
	
			if (dist < initialMovementDown) {
				dist = timer * 2f;
			}
		}
	}

	private void Clear(){
		Destroy (gameObject);
	}

	private void Reset(){
		timer = 0f;
		dist = 0f;
		move = true;
	}

	private void Stop(){
		move = false;
	}
}
