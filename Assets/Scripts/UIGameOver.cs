using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameOver : MonoBehaviour {

	void Update () {
		if (InputManager.spaceInput == SpaceInput.FOR_UI) {
			GameEventManager.TriggerTitleScreen ();
		}
	}
}
