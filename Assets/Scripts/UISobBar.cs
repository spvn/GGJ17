using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISobBar : MonoBehaviour {

	public float startingSobriety;
	public float dropProportion;
	public float dropInterval;

	public static float maxSobriety;

	private float startingScale;
	private float timer = 0f;

	void Awake() {
		maxSobriety = startingSobriety;
	}

	void Start () {
		startingScale = transform.localScale.x;
	}

	void Update () {
		timer += Time.deltaTime;

		if (timer > dropInterval) {
			timer = 0f;

			maxSobriety -= startingSobriety * dropProportion;
			transform.localScale -= new Vector3 (
				startingScale * dropProportion,
				0f,
				0f
			);

			if (maxSobriety <= 0f) {
				// game over
			}

		}
	}
}
