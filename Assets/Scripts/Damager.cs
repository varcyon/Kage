﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage = 5;

    [SerializeField] bool isStaticArea;


    void OnTriggerStay2D(Collider2D other)
    {
        if (isStaticArea)
        {
            Damageable controller = other.GetComponent<Damageable>();
            if (controller != null)
            {
                controller.TakeDamage(damage,0);
            }
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        Damageable controller = other.GetComponent<Damageable>();
        if (controller != null)
        {
            controller.TakeDamage(damage,0);
        }
        
    }
}
