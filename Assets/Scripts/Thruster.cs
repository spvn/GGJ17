using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : MonoBehaviour {

	public float maxThrustSize = 2f;

	private PlayerMovement pmovement;
	private Vector3 originalLocalScale;

	// Use this for initialization
	void Start () {
		pmovement = GetComponentInParent<PlayerMovement> ();
	
		originalLocalScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		float thrusterBoost = pmovement.getHoldRatio();
	
		transform.localScale = originalLocalScale 
			+ originalLocalScale * thrusterBoost * maxThrustSize;
	}
}
