using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMissile : MonoBehaviour {

	public float speed = 2f;

	void Awake () {
		GameEventManager.TitleScreen += Clear;
	}

	// Update is called once per frame
	void Update () {
		transform.position += transform.up * speed;
	}

	private void Clear(){
		Destroy (gameObject);
	}

	void OnDestroy() {
		GameEventManager.TitleScreen -= Clear;
	}
}
