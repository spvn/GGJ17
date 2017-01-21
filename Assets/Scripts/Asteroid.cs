using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

	public float speed = 1f;
	public float rotateSpeed = 10f;

	private Vector3 direction;
	// Use this for initialization
	void Start () {
		float xOffset = Random.Range (-0.5f, 0.5f);
		direction = new Vector3 (xOffset, -1f, 0f).normalized;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += direction * speed * Time.deltaTime;
		transform.Rotate (Vector3.forward * rotateSpeed * Time.deltaTime);
	}
}
