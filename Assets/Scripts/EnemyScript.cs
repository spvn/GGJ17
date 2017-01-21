using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	public float initialMovementTime = 1f;
	public float movementRange = 0.1f;

	private Vector3 targetPosition;
	private Vector3 origPos;
	private bool reachedPos = false;

	// Use this for initialization
	void Start () {
		targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0,Camera.main.pixelWidth), Random.Range(Camera.main.pixelHeight/2f, Camera.main.pixelHeight), Camera.main.nearClipPlane));

		origPos = transform.position;
		Debug.Log (origPos + " " + targetPosition);
		StartCoroutine (moveToPos(origPos, targetPosition, initialMovementTime));
	}
	
	// Update is called once per frame
	void Update () {
		if (reachedPos) {
			Vector3 movementVector = new Vector3 (Random.Range (-movementRange, movementRange), Random.Range (-movementRange, movementRange), 0f);
			reachedPos = false;
			StartCoroutine (moveToPos (transform.position, transform.position + movementVector, 1f));

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
