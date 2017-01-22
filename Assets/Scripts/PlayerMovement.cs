using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float sidewayMovementSpeed = 5f;
	public float maxSidewayMovement = 2.82f;
	public Vector3 boost;
	[HideInInspector]
	public float holdLimit;

	private bool allowMovement = true;
	private Vector3 startPosition;
	private float startSpeed;
	[HideInInspector]
	public bool isHolding = false;
	[HideInInspector]
	public bool holdValid = true;
	private float holdCounter;
	private float timeCount = 0f;

	private bool maxSobrietyChanged = false;

	void Awake() {
		GameEventManager.TitleScreen += StartMovement;
		GameEventManager.GameOver += StopMovement;

		startPosition = transform.position;
	}

	void Start () {
		//holdCounter = 0f;
		holdLimit = Health.currentMaxSobriety;
		holdCounter = holdLimit;
	} 

	void Update () {
		if (allowMovement) {
		/*	if (holdLimit != Health.currentMaxSobriety) {
				maxSobrietyChanged = true;
			} else {
				maxSobrietyChanged = false;
			}
	*/
			HandleInput ();

			if (!isHolding || !holdValid) {
				if (holdLimit == 0) {
					allowMovement = false;
					return;
				}
				timeCount += Time.deltaTime * holdCounter / holdLimit;
		//		if (maxSobrietyChanged) {
				//	float diff = holdLimit - Health.currentMaxSobriety;
				//	holdLimit = Health.currentMaxSobriety;
				//	holdCounter += diff;
			//	}
			} else {
				if (holdLimit == 0) {
					allowMovement = false;
					return;
				}
				timeCount += Time.deltaTime * Mathf.Pow (holdCounter / holdLimit, 4f);
			}

			transform.position = startPosition + new Vector3 (
				maxSidewayMovement * Mathf.Sin (timeCount * sidewayMovementSpeed),
				0f,
				0f
			);
			if (holdLimit == 0) {
				allowMovement = false;
				return;
			}
			Vector3 calculatedBoost = boost * Mathf.Pow ((1f - Mathf.Pow ((holdCounter / holdLimit), 2f)), 1f);
			transform.position = new Vector3 (
				transform.position.x, 
				transform.position.y + calculatedBoost.y,
				transform.position.z
			);
		}
			Debug.Log (holdLimit);
	}

	private void StartMovement() {
		allowMovement = true;

		transform.position = startPosition;
		holdLimit = GetComponentInChildren<Health>().startingSobriety; //Health.currentMaxSobriety;
		holdCounter = holdLimit;
		maxSobrietyChanged = false;
		isHolding = false;
		holdValid = true;
		timeCount = 0f;
	}

	private void StopMovement() {
		allowMovement = false;
	}

	void HandleInput() {
		if (InputManager.spaceInput == SpaceInput.FOR_MOVEMENT) {
			isHolding = true;
		} else {
			isHolding = false;
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

