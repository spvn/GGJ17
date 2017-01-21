using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameWin : MonoBehaviour {

	void Update () {
		if (InputManager.spaceInput == SpaceInput.FOR_UI) {
			GameEventManager.TriggerTitleScreen ();
		}
	}
}
