using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float sidewayMovementSpeed = 5f;
	public float maxSidewayMovement = 2.82f;
	public float holdLimit = 1000;

	private Vector3 startPosition;
	private Vector3 boost;
	private bool isHolding = false;
	private float holdCounter = 0;
	private float timeCount = 0f;

	void Start () {
		startPosition = transform.position;
		boost = Vector3.zero;
		holdCounter = holdLimit;
	}

	void Update () {
		HandleInput ();

		Debug.Log (holdCounter/holdLimit);

		if (isHolding) {
			
		} else {
			timeCount += Time.deltaTime;
			transform.position = startPosition + new Vector3 (
				maxSidewayMovement * Mathf.Sin (timeCount * sidewayMovementSpeed),
				0f,
				0f
			);
		}
	}

	void HandleInput() {
		if (Input.GetKey (KeyCode.Space)) {
			if (holdCounter > 0) {
				holdCounter -= Time.deltaTime;
				isHolding = true;
			} else {
				isHolding = false;
			}
		} else {
			isHolding = false;
			if (holdCounter < holdLimit) {
				holdCounter += Time.deltaTime;
			}
		}

		if (holdCounter < 0f) {
			holdCounter = 0f;
		}

		if (holdCounter > holdLimit) {
			holdCounter = holdLimit;
		}
	}
}

