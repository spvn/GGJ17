using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {

	public float spawnInterval = 0.5f;
	public GameObject asteroid;

	private bool spawn = false;
	private float currSpawnInterval = 0f;

	void Awake () {
		GameEventManager.GameStart += DoSpawn;
		GameEventManager.GameWin += DontSpawn;
		GameEventManager.GameOver += DontSpawn;
		GameEventManager.TitleScreen += DontSpawn;
	}
	
	// Update is called once per frame
	void Update () {
		if (spawn) {
			currSpawnInterval += Time.deltaTime;

			if (currSpawnInterval >= spawnInterval) {
				spawnAsteroid ();
				currSpawnInterval = 0f;
			}
		}
	}
		
	private void DoSpawn(){
		spawn = true;
	}

	private void DontSpawn(){
		spawn = false;
	}

	void spawnAsteroid() {
		GameObject.Instantiate (asteroid,transform.position, Quaternion.identity);
	}
}
