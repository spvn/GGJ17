using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITitleScreen : MonoBehaviour {
	
	void Update () {
		if (InputManager.spaceInput == SpaceInput.FOR_UI) {
			GameEventManager.TriggerGameStart ();
		}
	}
}
