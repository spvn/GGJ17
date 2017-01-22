using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHit : MonoBehaviour {

	public Renderer rend;
	public bool isHit;
	public float HP = 100f;

	public GameObject explosion1;
	public GameObject explosion2;
	public GameObject explosion3;

	private bool hasTriggeredWin = false;

	void Avoid() {
		//GameEventManager.GameWin += Clear;
	}

	void Start () {
		rend = this.GetComponent<Renderer> ();

		explosion1.SetActive (false);
		explosion2.SetActive (false);
		explosion3.SetActive (false);
	}

	void Update () {
		if(isHit){
			StartCoroutine (hitAnimation(1));
			isHit = false;
		}

		if (HP <= 0 && !hasTriggeredWin) {
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
			HP -= 10f;
		}
	}

	void KillBoss(){
		hasTriggeredWin = true;

		explosion1.SetActive (true);
		explosion2.SetActive (true);
		explosion3.SetActive (true);

		GameEventManager.TriggerGameWin ();
	}
		
}
