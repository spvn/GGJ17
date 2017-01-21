using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpaceInput {
	NO_INPUT,
	FOR_MOVEMENT,
	FOR_UI
}

public class InputManager : MonoBehaviour {

	public static SpaceInput spaceInput = SpaceInput.NO_INPUT;

	private bool isInGame = false;

	void Awake() {
		GameEventManager.GameStart += setIsInGame;
		GameEventManager.TitleScreen += setIsNotInGame;
		GameEventManager.GameOver += setIsNotInGame;
		GameEventManager.GameWin += setIsNotInGame;
	}

	void Update () {
		if (isInGame) {
			if (Input.GetKey (KeyCode.Space)) {
				spaceInput = SpaceInput.FOR_MOVEMENT;
			} else {
				spaceInput = SpaceInput.NO_INPUT;
			}
		} else {
			if (Input.GetKeyDown (KeyCode.Space)) {
				spaceInput = SpaceInput.FOR_UI;
			} else {
				spaceInput = SpaceInput.NO_INPUT;
			}
		}

	//	Debug.Log (spaceInput);
	}

	private void setIsInGame(){
		isInGame = true;
	}

	private void setIsNotInGame(){
		isInGame = false;
	}
}
