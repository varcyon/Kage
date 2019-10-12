using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;
    public int health { get { return currentHealth; } }

    public bool recovering;
    public float recoveryCounter;
    public float recoveryTime = 2;
     Animator animator;
    public GameObject parent;

    [SerializeField] GameObject deathParticles;


    public GameObject head;
    public GameObject Feet;
    public GameObject leg;
    public GameObject Lhand;
    public GameObject Rhand;
    public GameObject torsoU;
    public GameObject torsoL;
    public GameObject shoulder;



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



    }

    private void Die()
    {
        deathParticles.SetActive(true);
        deathParticles.transform.parent = transform.parent;
        Destroy(gameObject);
    }

    public void TakeDamage(int amount, int launchDirection, Vector2 launchPower)
    {

        if (!recovering)
        {
            // if(parent.layer == 8){
            //     Player.Instance.cameraEffect.Shake (100f,1f);
            // }
            recoveryCounter = 0;
            recovering = true;
            currentHealth = Mathf.Clamp(currentHealth - amount, 0, maxHealth);
            animator.SetTrigger("Hurt");
            parent.GetComponent<Rigidbody2D>().AddForce(new Vector2(launchPower.x*launchDirection, launchPower.y));
            

        }
        if (health <= 0)
        {
            if (parent.layer == 8)
            {
                parent.GetComponent<SpriteRenderer>().enabled = false;
                parent.GetComponent<Player>().enabled = false;
                parent.GetComponent<CapsuleCollider2D>().enabled = false;

                Instantiate(head, parent.transform.position, Quaternion.identity);
                Instantiate(Feet, parent.transform.position, Quaternion.identity);
                Instantiate(Feet, parent.transform.position, Quaternion.identity);
                Instantiate(leg, parent.transform.position, Quaternion.identity);
                Instantiate(leg, parent.transform.position, Quaternion.identity);
                Instantiate(shoulder, parent.transform.position, Quaternion.identity);
                Instantiate(shoulder, parent.transform.position, Quaternion.identity);
                Instantiate(Lhand, parent.transform.position, Quaternion.identity);
                Instantiate(Rhand, parent.transform.position, Quaternion.identity);
                Instantiate(torsoU, parent.transform.position, Quaternion.identity);
                Instantiate(torsoL, parent.transform.position, Quaternion.identity);

            }
            else
            {
                Die();
            }
        }
    }

    public void increaseHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}
