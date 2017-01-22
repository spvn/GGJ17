using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

	public PlayerShoot playerShoot;
	public Health playerHealth;
	public Shield playerShield;

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
				} else if (other.gameObject.tag == "EnemyBullet" || other.gameObject.tag == "Asteroid") {
					Destroy (other.gameObject);
				}
			}
		}
	}
}
