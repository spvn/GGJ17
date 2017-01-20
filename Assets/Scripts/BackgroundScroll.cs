using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour {

	public float speed = 0.5f;

	private MeshRenderer renderer;
	// Use this for initialization
	void Start () {
		renderer = GetComponent<MeshRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 offset = new Vector2 (0f, Time.time * speed);

		renderer.material.mainTextureOffset = offset;
	}
}
