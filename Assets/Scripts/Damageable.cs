using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : physticsObject
{
    public int maxHealth = 5;
    public int currentHealth;
    public int health { get { return currentHealth; } }
    public float launch = 1;
    public Vector2 launchPower;
    public bool recovering;
    public float recoveryCounter;
    public float recoveryTime = 2;
    public float launchRecovery;
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }
    void FixedUpdate()
    {
        if (recovering)
        {
            recoveryCounter += Time.deltaTime;
            if (recoveryCounter >= recoveryTime)
            {
                recoveryCounter = 0;
                recovering = false;
            }
        }


        if(health <=0){
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int amount, int launchDirection)
    {
        if(!recovering){
            velocity.y = launchPower.y;
            launch = launchDirection * (launchPower.x);
            recoveryCounter = 0;
            recovering = true;
            currentHealth = Mathf.Clamp(currentHealth - amount, 0, maxHealth);
            Debug.Log("Ouch!");
            //animator.SetTrigger("Hurt");
        }
    }

    public void increaseHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}
