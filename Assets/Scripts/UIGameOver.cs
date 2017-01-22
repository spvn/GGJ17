using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameOver : MonoBehaviour {

	private float timer = 0f;

	void Update () {
		timer += Time.deltaTime;

		if (timer > 2f && InputManager.spaceInput == SpaceInput.FOR_UI) {
			timer = 0f;
			GameEventManager.TriggerTitleScreen ();
		}
	}

	IEnumerator WaitABit(){
		yield return new WaitForSeconds (2f);
	}
}
