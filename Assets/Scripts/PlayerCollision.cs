using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

	public Health playerHealth;
	public Shield playerShield;

	void Start () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other){
	//	Debug.Log (other.name + " hit the player");

	//	if (other.gameObject.layer != LayerMask.NameToLayer("PlayerShots")){
			if (other.gameObject.layer == LayerMask.NameToLayer ("Powerups")) {
				Powerup pup = other.GetComponent<Powerup> ();	

				if (pup && !pup.gotCollected) {
					if (other.tag == "Healthpack") {
						playerHealth.addHealth ();
						pup.collectPowerup ();
					} else if (other.tag == "Shield") {
						pup.collectPowerup ();
					}
				}
			} else {
				playerHealth.reduceHealth ();
			}
	//	}
	}
}
