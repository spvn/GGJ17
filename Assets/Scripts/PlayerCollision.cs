using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

	public PlayerShoot playerShoot;
	public Health playerHealth;
	public Shield playerShield;

	private float duration = 1f;
	private AudioSource sfx;
	void Start () {
		sfx = GetComponent<AudioSource> ();
	}
	
	void OnTriggerEnter2D(Collider2D other){
	//	Debug.Log (other.name + " hit the player");

		if (other.gameObject.layer != LayerMask.NameToLayer("PlayerShots")){
			if (other.gameObject.layer == LayerMask.NameToLayer ("Powerups")) {
				Powerup pup = other.GetComponent<Powerup> ();	

				if (pup && !pup.gotCollected) {
					if (other.tag == "Healthpack") {
						playerHealth.addHealth ();
						pup.collectPowerup ();
					} else if (other.tag == "Shield") {
						playerShield.activateShield (2f);
						pup.collectPowerup ();
					} else if (other.tag == "ShootBoost") {
						playerShoot.boostShooting ();
						pup.collectPowerup ();
					}
				}
			} else {
				if ((other.gameObject.tag == "EnemyBullet" || other.gameObject.tag == "Asteroid") && !playerHealth.isInvulnerable) {
					playerHealth.reduceHealth ();
					sfx.Play ();
					StartCoroutine(Shake ());
				} else if (other.gameObject.tag == "EnemyBullet" || other.gameObject.tag == "Asteroid") {
					Destroy (other.gameObject);
				}
			}
		}
	}

	/*
	void CameraShake() {
		float shake = 1f;
		float decreaseFactor = 0.1f;
		float shakeAmount = 1f;
		if (shake > 0f) {
			Vector3 shakeVector = Random.insideUnitCircle * shakeAmount;
			Camera.main.transform.localPosition += shakeVector;
			shake -= Time.deltaTime * decreaseFactor;

		} else {
			shake = 0f;
		}
	}*/

	IEnumerator Shake() {

		float elapsed = 0.0f;

		Vector3 originalCamPos = Camera.main.transform.position;

		while (elapsed < duration) {

			elapsed += Time.deltaTime;          

			float percentComplete = elapsed / duration;         
			float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

			// map value to [-1, 1]
			float x = Random.value * 2.0f - 1.0f;
			float y = Random.value * 2.0f - 1.0f;
			x *= 0.25f * damper;
			y *= 0.25f * damper;

			Camera.main.transform.position = new Vector3(x, y, originalCamPos.z);

			yield return null;
		}

		Camera.main.transform.position = originalCamPos;
	}
}
