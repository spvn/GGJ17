using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour {

	void Awake () {
		GetComponent<TrailRenderer> ().sortingLayerName = "Character";
	}

}
