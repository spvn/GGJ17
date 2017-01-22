using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour {

	public bool drunk = false;
	public float speed = 0.5f;
	public float colourSpeed = 1f;
	private bool isRandomising = false;
	private IEnumerator coroutine;

	private MeshRenderer renderer;
	// Use this for initialization
	void Start () {
		renderer = GetComponent<MeshRenderer> ();
		coroutine = randomiseColours ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 offset = new Vector2 (0f, Time.time * speed);

		renderer.material.mainTextureOffset = offset;

		if (drunk && !isRandomising) {
			Debug.Log ("fired");
			StartCoroutine (coroutine);
			isRandomising = true;
			//renderer.material.SetColor ("_Color", new Color32 (255, 0, 0, 255));
		} else if (!drunk && isRandomising){
			Debug.Log ("unfired");

			isRandomising = false;
			StopCoroutine (coroutine);
			renderer.material.SetColor ("_Color", Color.white);
		}

	}
	/*
	IEnumerator randomiseColours() {

		while (true) {
			float randHue = Random.Range (0f, 1f);

			Color32 randColor = Color.HSVToRGB (randHue, 1f, 1f);

			Color32 currColor = renderer.material.color;
			float duration = 0f;

			while (duration < 0.5f) {
				renderer.material.SetColor ("_Color", Color.Lerp (currColor, randColor, duration / 0.5f));
				duration += Time.deltaTime;
				yield return null;
			}

			yield return null;
		}

	}*/

	IEnumerator randomiseColours() {
		while (true) {
			Debug.Log ("in coroutine");
			float hue = Mathf.PingPong (Time.time * colourSpeed, 1f);
			renderer.material.SetColor ("_Color", Color.HSVToRGB (hue, 1f, 1f));
			yield return null;
		}
	}
}
