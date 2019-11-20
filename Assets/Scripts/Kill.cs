using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    // Start is called before the first frame update
 private void OnCollisionEnter2D(Collision2D other) {
other.gameObject.GetComponent<Damageable>().recoveryCounter = 0;
    other.gameObject.GetComponent<Damageable>().TakeDamage(1000,0,new Vector2(0,0));
}
}
