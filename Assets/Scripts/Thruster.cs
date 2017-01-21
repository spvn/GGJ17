using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : MonoBehaviour {

	public float maxThrustSize = 2f;

	private PlayerMovement pmovement;
	private SpriteRenderer sr;
	private Vector3 originalLocalScale;

	void Awake(){
		GameEventManager.TitleScreen += ShowThruster;
		GameEventManager.GameOver += DontShowThruster;
	}

	void Start () {
		pmovement = GetComponentInParent<PlayerMovement> ();
		sr = GetComponent<SpriteRenderer> ();
	
		originalLocalScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		float thrusterBoost = pmovement.getHoldRatio();
	
		transform.localScale = originalLocalScale 
			+ originalLocalScale * thrusterBoost * maxThrustSize;
	}

	private void ShowThruster(){
		sr.enabled = true;
	}

	private void DontShowThruster(){
		sr.enabled = false;
	}
}
