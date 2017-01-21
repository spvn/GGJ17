using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float sidewayMovementSpeed = 5f;
	public float maxSidewayMovement = 2.82f;
	public float holdLimit = 1000;
	public Vector3 boost;

	private Vector3 startPosition;
	private bool isHolding = false;
	private bool holdValid = true;
	private float holdCounter = 0;
	private float timeCount = 0f;

	void Start () {
		startPosition = transform.position;
		holdCounter = 0f;
	}

	void Update () {
		HandleInput ();

		timeCount += Time.deltaTime;
		transform.position = startPosition + new Vector3 (
			maxSidewayMovement * Mathf.Sin (timeCount * sidewayMovementSpeed),
			0f,
			0f
		);

	//	Debug.Log (holdCounter / holdLimit);

		Vector3 calculatedBoost = boost * holdCounter / holdLimit;
		transform.position = new Vector3 (
			transform.position.x, 
			transform.position.y + calculatedBoost.y,
			transform.position.z
		);
	}

	void HandleInput() {
		if (Input.GetKey (KeyCode.Space)) {
			isHolding = true;
		} else {
			isHolding = false;
		}

		if (isHolding) {
			if (holdValid) {
				holdCounter += Time.deltaTime;

				if (holdCounter > holdLimit) {
					holdValid = false;
				}
			} else {
				holdCounter -= Time.deltaTime;
			}
		} else {
			holdCounter -= Time.deltaTime;
			holdValid = true;
		}

		if (holdCounter < 0f) {
			holdCounter = 0f;
		}

		if (holdCounter > holdLimit) {
			holdCounter = holdLimit;
		}
	}

	public float getHoldRatio() {
		return holdCounter/holdLimit;
	}
}

