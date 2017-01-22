using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public float waveInterval = 3f;

	private float timer = 0f;
	private float overallTimer = 0f;
	private BossSpawner boss;
	private bool spawning = false;
	private float bossTime;
	public GameObject enemy;
	// Use this for initialization
	void Start () {
		GameEventManager.TitleScreen += StopSpawning;
		GameEventManager.GameWin += StopSpawning;
		GameEventManager.GameOver += StopSpawning;
		GameEventManager.GameStart += StartSpawning;
		GameEventManager.GameStart += resetTimer;

		boss = FindObjectOfType<BossSpawner> ().GetComponent<BossSpawner> ();
		bossTime = boss.spawnTime - 5f;
	}
	
	// Update is called once per frame
	void Update () {
		if (spawning) {
			if (timer < waveInterval) {
				timer += Time.deltaTime;
			} else {
				timer = 0f;
				SpawnEnemy ();
			}
		}
	}

	void SpawnEnemy() {
		if (ObstacleManager.enemyCount < ObstacleManager.maxEnemyCount) {
			int numToSpawn = ObstacleManager.maxEnemyCount - ObstacleManager.enemyCount;
			for (int i = 0; i < numToSpawn; i++) {
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

		if (overallTimer > bossTime) {
			StopSpawning ();
		} else {
			overallTimer += Time.deltaTime;
		}

	}

	void StopSpawning () {
		spawning = false;
	}
	void resetTimer() {
		overallTimer = 0f;
		timer = 0f;
	}
	void StartSpawning() {
		spawning = true;
	}
}
