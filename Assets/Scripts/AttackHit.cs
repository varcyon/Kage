using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHit : MonoBehaviour {

	[SerializeField] enum AttacksWhat {Damageable};
	[SerializeField] AttacksWhat attacksWhat;
	private int launchDirection = 1;
	[SerializeField] private GameObject parent;
	[SerializeField]bool heavyAttack;
	[SerializeField]bool rangedAttack;
	[SerializeField]bool closeAttack;

	

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.GetComponent(attacksWhat.ToString()) != null) {
			if (parent.transform.position.x < other.transform.position.x) {
				launchDirection = 1;
			} else {
				launchDirection = -1;
			}
			int dmg = GetComponent<Damager>().damage;
	
			Vector2 launchPower = GetComponent<Damager>().launchPower;
			other.GetComponent<Damageable>().TakeDamage(dmg, launchDirection,launchPower);
			
		}
		
	}
}
