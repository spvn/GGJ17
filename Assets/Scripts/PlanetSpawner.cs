using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour {

	public GameObject[] planets;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnPlanets", 0f, 0.7f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnPlanets() {
		if (Random.Range (0f, 1f) < 0.3f) {
			int index = Random.Range (0, planets.Length);
			float xPos = Random.Range (-3.5f, 3.5f);
			float zPos = 0f;
			if (index == 0) {
				zPos = 0.09f;
			} else if (index == 1) {
				zPos = 0.08f;
			} else if (index == 2) {
				zPos = 0.07f;
			}
			Instantiate (planets [index], new Vector3 (xPos, transform.position.y, zPos), Quaternion.identity);

		}
	}
}
