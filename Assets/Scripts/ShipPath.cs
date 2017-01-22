using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPath : MonoBehaviour {

	public float completionTime = 5f;
	public Transform playerShip;
	public Transform destination;

	[HideInInspector]
	public bool move = false;
	private Vector3 startPosition;
	private float distance;
	private float timer = 0f;

	void Awake () {
		GameEventManager.TitleScreen += Reset;
		GameEventManager.GameStart += StartMovement;
		GameEventManager.GameOver += StopMovement;
		GameEventManager.GameWin += StopMovement;

		startPosition = transform.position;
		distance = destination.position.y - startPosition.y;
	}
	
	void Start(){
		distance = destination.position.y - startPosition.y;
	}

	void Update () {
		Debug.Log ("here");
		if (move) {
			Debug.Log ("move");
			timer += Time.deltaTime;
			transform.position = startPosition + (timer / completionTime) * distance * Vector3.up
			+ 0.1f * playerShip.position;
		
			if (Mathf.Abs (transform.position.y - destination.position.y) < 0.05f) {
				move = false;
			}
		}
	}

	private void Reset(){
		transform.position = startPosition;
		timer = 0f;
	}

	private void StartMovement(){
		move = true;
	}

	private void StopMovement(){
		move = false;
	}
}
