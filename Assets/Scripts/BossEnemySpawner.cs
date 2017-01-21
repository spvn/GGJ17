using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemySpawner : MonoBehaviour {

	public float spawnTime;
	public GameObject bossEnemy;

	private float timer = 0f;

	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (timer < spawnTime) {
			timer+=Time.deltaTime;
		} else {
			timer = 0f;
			SpawnEnemy ();
		}
	}

	void SpawnEnemy() {
		GameObject enemy = Instantiate (bossEnemy, this.transform.position, Quaternion.identity);
		enemy.transform.parent = this.transform;
	}
}
