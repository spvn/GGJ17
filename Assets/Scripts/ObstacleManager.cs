using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour {

	public static int enemyCount = 0;
	public static int maxEnemyCount = 1;
	public static float difficultyIncreaseInterval = 1f;
	public static float currDifficulty = 0f;

	public float difficultyIncreaseMultiplier = 2f;
	// Use this for initialization
	void Start () {
		GameEventManager.GameStart += ResetDifficulty;
	}
	
	// Update is called once per frame
	void Update () {
		if (currDifficulty > difficultyIncreaseInterval) {
			currDifficulty = 0f;
			increaseDifficulty ();
			difficultyIncreaseInterval *= difficultyIncreaseMultiplier;
		}

	}

	void increaseDifficulty() {
		Debug.Log ("increasing");
		maxEnemyCount++;
	}

	public static void addDifficulty(float additional) {

		currDifficulty += additional;
		//Debug.Log (currDifficulty);
	}

	void ResetDifficulty() {
		currDifficulty = 0f;
		maxEnemyCount = 1;
	}
}
