using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {

	public float spawnInterval = 0.5f;
	public GameObject asteroid;

	private float currSpawnInterval = 0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		currSpawnInterval += Time.deltaTime;

		if (currSpawnInterval >= spawnInterval) {
			spawnAsteroid ();
			currSpawnInterval = 0f;
		}
	}



	void spawnAsteroid() {
		GameObject.Instantiate (asteroid,transform.position, Quaternion.identity);
	}
}
