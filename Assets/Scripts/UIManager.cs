using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

	public GameObject titleScreen;
	public GameObject mainUI;
	public GameObject gameOverScreen;

	void Awake() {
		GameEventManager.GameStart += ShowStartGameUI;
		GameEventManager.TitleScreen += ShowTitleScreen;
		GameEventManager.GameOver += ShowGameOverScreen;
	}

	void Start(){
		GameEventManager.TriggerTitleScreen ();
	}

	private void ShowTitleScreen(){
		titleScreen.SetActive (true);
		mainUI.SetActive (false);
		gameOverScreen.SetActive (false);
	}

	private void ShowStartGameUI(){
		titleScreen.SetActive (false);
		mainUI.SetActive (true);
		gameOverScreen.SetActive (false);
	}

	private void ShowGameOverScreen(){
		titleScreen.SetActive (false);
		mainUI.SetActive (false);
		gameOverScreen.SetActive (true);
	}
}
