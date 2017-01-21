using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHit : MonoBehaviour {

	public Renderer rend;
	public bool isHit;
	public float HP = 100f;

	// Use this for initialization
	void Start () {
		rend = this.GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(isHit){
			StartCoroutine (hitAnimation(1));
			isHit = false;
		}

		if (HP <= 0) {
			KillBoss ();
		}
	}

	IEnumerator hitAnimation(int num) {
		rend.material.SetColor ("_Color", new Color32 (220, 0, 0, 255));
		yield return new WaitForSeconds (0.2f);
		rend.material.SetColor ("_Color", Color.white);
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "PlayerBullet") {
			isHit = true;
			HP -= 20f;
		}
	}

	void KillBoss(){

		Destroy (gameObject);
	}
}
