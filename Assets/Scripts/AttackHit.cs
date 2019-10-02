using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHit : MonoBehaviour {

	[SerializeField] enum AttacksWhat {Damageable};
	[SerializeField] AttacksWhat attacksWhat;
	private int launchDirection = 1;
	[SerializeField] private GameObject parent;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.GetComponent(attacksWhat.ToString()) != null) {
			if (parent.transform.position.x < other.transform.position.x) {
				launchDirection = 1;
			} else {
				launchDirection = -1;
			}
			int dmg = parent.GetComponent<Damager>().damage;
			Vector2 launchPower = parent.GetComponent<Damager>().launchPower;
			other.GetComponent<Damageable>().TakeDamage(dmg, launchDirection,launchPower);
			
		}
		
	}
}
