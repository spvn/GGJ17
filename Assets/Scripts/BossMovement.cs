using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour {
	
	public float xAxisSpeed = 5f;
	public float maxX = 1.5f; 

	private Vector3 startPos;
	private float timer = 0f;
	// Use this for initialization
	void Start () {
		
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		transform.position = startPos + new Vector3 (maxX * Mathf.Sin (xAxisSpeed* timer),0f,0f);
	}

}
