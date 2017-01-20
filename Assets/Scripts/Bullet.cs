using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed = 2f;
	public float damage = 1f;
	public Vector3 direction = new Vector3();

	void Start () {
		
	}

	void Update () {
		transform.localPosition += direction * speed * Time.deltaTime;
	}
}
