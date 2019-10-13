using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectable : MonoBehaviour
{
public int restoreHealth = 1;
void OnTriggerEnter2D(Collider2D other){
    Damageable controller = other.GetComponent<Damageable>();

    if(controller != null && other.gameObject.layer == 8){
        if(controller.health < controller.maxHealth){
        controller.increaseHealth(restoreHealth);
        Destroy(gameObject);
        }
    }
}
}
