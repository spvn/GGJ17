using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISobBarFiller : MonoBehaviour {

	public PlayerMovement pm;
	private Vector3 startingScale;
	private float sobRatio;

	void Start () {
		startingScale = transform.localScale;
	}

	void Update () {
		sobRatio = pm.getHoldRatio ();
		transform.localScale = new Vector3(
			startingScale.x * sobRatio,
			startingScale.y,
			startingScale.z
		);
	}
}
