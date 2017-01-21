using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

	public GameObject titleScreen;
	public GameObject mainUI;
	public GameObject gameOverScreen;
	public GameObject gameWinScreen;

	void Awake() {
		GameEventManager.GameStart += ShowStartGameUI;
		GameEventManager.TitleScreen += ShowTitleScreen;
		GameEventManager.GameOver += ShowGameOverScreen;
		GameEventManager.GameWin += ShowGameWinScreen;
	}

	void Start(){
		GameEventManager.TriggerTitleScreen ();
	}

	private void ShowTitleScreen(){
		titleScreen.SetActive (true);
		mainUI.SetActive (false);
		gameOverScreen.SetActive (false);
		gameWinScreen.SetActive (false);
	}

	private void ShowStartGameUI(){
		titleScreen.SetActive (false);
		mainUI.SetActive (true);
		gameOverScreen.SetActive (false);
		gameWinScreen.SetActive (false);
	}

	private void ShowGameOverScreen(){
		titleScreen.SetActive (false);
		mainUI.SetActive (false);
		gameOverScreen.SetActive (true);
		gameWinScreen.SetActive (false);
	}

	private void ShowGameWinScreen(){
		titleScreen.SetActive (false);
		mainUI.SetActive (false);
		gameOverScreen.SetActive (false);
		gameWinScreen.SetActive (true);
	}
}
