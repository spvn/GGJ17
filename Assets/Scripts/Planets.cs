using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planets : MonoBehaviour {

	public float speed = 5f;
	private float killTime = 10f;
	private float lifeTime = 0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.down * Time.deltaTime * speed;

		if (lifeTime > killTime) {
			Destroy (gameObject);
		} else {
			lifeTime += Time.deltaTime;
		}
	}
}
