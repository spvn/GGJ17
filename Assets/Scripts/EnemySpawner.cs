using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public float waveInterval = 3f;

	private float timer = 0f;

	public GameObject enemy;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (timer < waveInterval) {
			timer+=Time.deltaTime;
		} else {
			timer = 0f;
			Debug.Log ("here");
			SpawnEnemy ();
		}
	}

	void SpawnEnemy() {
		if (ObstacleManager.enemyCount < ObstacleManager.maxEnemyCount) {
			for (int i = 0; i < ObstacleManager.maxEnemyCount; i++) {
				int sideToSpawn = Random.Range (0, 2);

				float xPos;
				float yPos;
				if (sideToSpawn == 0) {
					xPos = Random.Range (-7f, -4f);
					yPos = Random.Range (6f, 9f);
				} else if (sideToSpawn == 1) {
					xPos = Random.Range (-7f, 7f);
					yPos = Random.Range (2f, 8f);

				} else {
					xPos = Random.Range (4f, 7f);
					yPos = Random.Range (2f, 8f);
				}


				Instantiate (enemy, new Vector3(xPos, yPos, 0f), Quaternion.identity);
				ObstacleManager.enemyCount++;
			}
		}

	}
}
