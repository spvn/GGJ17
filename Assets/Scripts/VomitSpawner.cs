using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VomitSpawner : MonoBehaviour {

	public Sprite[] sprites;

	private SpriteRenderer[] renderers;
	// Use this for initialization
	void Start () {
		renderers = GetComponentsInChildren<SpriteRenderer> ();
		SpawnVomit ();
	}
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnVomit() {
		

		foreach (SpriteRenderer sr in renderers) {
			sr.sprite = sprites [Random.Range (0, sprites.Length)];
			sr.color = new Color32 (73, 216, 109, 255);
		}

		StartCoroutine (fadeOut());

	}

	IEnumerator fadeOut() {

		yield return new WaitForSeconds (2f);

		float duration = 0f;
		float totalTime = 1f;

		while (duration < totalTime) {
			foreach (SpriteRenderer sr in renderers) {
				
				sr.color = Color32.Lerp (new Color32 (73, 216, 109, 255), new Color32 (73, 216, 109, 0), duration / totalTime);
			}
			duration += Time.deltaTime;
			yield return null;
		}
	}
}
