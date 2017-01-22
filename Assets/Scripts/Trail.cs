using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour {

	public PlayerMovement pm;

	private TrailRenderer tr;

	void Awake () {
		tr = GetComponent<TrailRenderer> ();
		tr.sortingLayerName = "Character";
	}

	void Update(){
		if (pm.isHolding && pm.holdValid) {
			tr.enabled = true;
		} else {
			tr.enabled = false;
		}
	}
}