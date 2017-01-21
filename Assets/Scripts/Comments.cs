using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comments : MonoBehaviour {

	public List<string> comments;

	private TextMesh tm;

	void Start () {
		tm = GetComponent<TextMesh> ();
	}
	

	void Update () {
		
	}
}
