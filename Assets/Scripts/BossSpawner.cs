using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour {

	public float spawnTime = 102f;
	public GameObject boss;

	private bool startTimer = false;
	private float timer = 0f;

	void Start () {
		GameEventManager.TitleScreen += StopTimer;
		GameEventManager.GameStart += StartTimer;
		GameEventManager.GameOver += StopTimer;
		GameEventManager.GameWin += StopTimer;
	}

	void Update () {
		if (startTimer) {
			timer += Time.deltaTime;

			if (timer > spawnTime) {
				startTimer = false;
				Instantiate (boss, transform.position, Quaternion.identity);
			}
		}
	}

	private void StartTimer(){
		startTimer = true;
		timer = 0f;
	}

	private void StopTimer(){
		startTimer = false;
	}
}
