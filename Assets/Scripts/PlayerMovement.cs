using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float sidewayMovementSpeed = 5f;
	public float maxSidewayMovement = 2.82f;

	private Vector3 startPosition;
	private Vector3 boost;

	void Start () {
		startPosition = transform.position;
	}

	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			Debug.Log ("holding spacebar");
		}

		transform.position = startPosition + new Vector3 (
			maxSidewayMovement * Mathf.Sin (Time.time * sidewayMovementSpeed) ,
			startPosition.y,
			startPosition.z
		);
	}
}

