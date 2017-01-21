using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISobBar : MonoBehaviour {

	public Health playerHealth;
	private Vector3 startingScale;

	void Awake() {
		GameEventManager.GameStart += Reset;
		startingScale = transform.localScale;
	}

	void Start () {
		
	}

	void Update () {
		transform.localScale = new Vector3 (
			startingScale.x * playerHealth.getHealthProportion(),
			startingScale.y,
			startingScale.z
		);
	}

	private void Reset(){
		transform.localScale = startingScale;
	}
}
