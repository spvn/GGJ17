using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemy;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnEnemy", 0f, 3f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnEnemy() {
		Instantiate (enemy, transform.position, Quaternion.identity);


	}
}
