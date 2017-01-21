using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float sidewayMovementSpeed = 5f;
	public float maxSidewayMovement = 2.82f;
	public float holdLimit = 1000;
	public Vector3 boost;

	private Vector3 startPosition;
	private float startSpeed;
	private bool isHolding = false;
	private bool holdValid = true;
	private float holdCounter;
	private float timeCount = 0f;

	private bool holdStartSet = false;
	private Vector3 holdStartPosition;

	void Start () {
		startPosition = transform.position;
		//holdCounter = 0f;
		holdCounter = holdLimit;
	} 

	void Update () {
		HandleInput ();

/*		if (isHolding && holdValid) {
			timeCount += Time.deltaTime;
			transform.position = holdStartPosition + new Vector3 (
				maxSidewayMovement * Mathf.Sin (timeCount * holdCounter/holdLimit),
				0f,
				0f
			);
		} else {
*/		
		if (!isHolding || !holdValid) {
			timeCount += Time.deltaTime * holdCounter / holdLimit;
		} else {
			timeCount += Time.deltaTime * Mathf.Pow (holdCounter / holdLimit, 4f);
		}

		transform.position = startPosition + new Vector3 (
			maxSidewayMovement * Mathf.Sin (timeCount * sidewayMovementSpeed),
			0f,
			0f
		);
//		}

		Vector3 calculatedBoost = boost * Mathf.Pow((1f - Mathf.Pow((holdCounter / holdLimit), 2f)), 1f);
		transform.position = new Vector3 (
			transform.position.x, 
			transform.position.y + calculatedBoost.y,
			transform.position.z
		);

	//	Debug.Log (calculatedBoost);
	}

	void HandleInput() {
		if (Input.GetKey (KeyCode.Space)) {
			isHolding = true;
			if (!holdStartSet) {
				holdStartSet = true;
				holdStartPosition = transform.position;
			}
		} else {
			isHolding = false;
			holdStartSet = false;
		}

		if (isHolding) {
			/*if (holdValid) {
				holdCounter += Time.deltaTime;
				if (holdCounter > holdLimit) {
					holdValid = false;
				}
			} else {
				holdCounter -= Time.deltaTime;
			}*/
			if (holdValid) {
				holdCounter -= Time.deltaTime;
				if (holdCounter < 0f) {
					holdValid = false;
				}
			} else {
				holdCounter += Time.deltaTime;
			}
		} else {
			//holdCounter -= Time.deltaTime;
			holdValid = true;
			holdCounter += Time.deltaTime;
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

