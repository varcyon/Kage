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
    [SerializeField] GameObject purgatoryWaterFragment;
    [SerializeField] GameObject hellFireFragment;
    [SerializeField] GameObject heavenMetalFragment;


    GameObject head;
    GameObject Feet;
    GameObject leg;
    GameObject Lhand;
    GameObject Rhand;
    GameObject torsoU;
    GameObject torsoL;
    GameObject shoulder;



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
        int PWamount = UnityEngine.Random.Range(1, 5);
        int HFamount = UnityEngine.Random.Range(1, 5);
        int HMamount = UnityEngine.Random.Range(1, 5);
        for (int i = 0; i < PWamount; i++)
        {
             GameObject clone = Instantiate(purgatoryWaterFragment, new Vector2(transform.position.x + UnityEngine.Random.Range(-5,5),transform.position.y + UnityEngine.Random.Range(0,5)), Quaternion.identity);
           //  clone.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 100);
        }
        for (int i = 0; i < HFamount; i++)
        {
             GameObject clone = Instantiate(hellFireFragment, new Vector2(transform.position.x + UnityEngine.Random.Range(-5,5),transform.position.y + UnityEngine.Random.Range(0,5)), Quaternion.identity);
           //  clone.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 100);
        }
        for (int i = 0; i < HMamount; i++)
        {
          GameObject clone = Instantiate(heavenMetalFragment, new Vector2(transform.position.x + UnityEngine.Random.Range(-5,5),transform.position.y + UnityEngine.Random.Range(0,5)), Quaternion.identity);
         // clone.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 100);
          
        }


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
            parent.GetComponent<Rigidbody2D>().AddForce(new Vector2(launchPower.x * launchDirection, launchPower.y));


        }
        if (health <= 0)
        {
            if (parent.layer == 8)
            {
                parent.GetComponent<SpriteRenderer>().enabled = false;
                parent.GetComponent<Player>().enabled = false;
                parent.GetComponent<CapsuleCollider2D>().enabled = false;

                // Instantiate(head, parent.transform.position, Quaternion.identity);
                // Instantiate(Feet, parent.transform.position, Quaternion.identity);
                // Instantiate(Feet, parent.transform.position, Quaternion.identity);
                // Instantiate(leg, parent.transform.position, Quaternion.identity);
                // Instantiate(leg, parent.transform.position, Quaternion.identity);
                // Instantiate(shoulder, parent.transform.position, Quaternion.identity);
                // Instantiate(shoulder, parent.transform.position, Quaternion.identity);
                // Instantiate(Lhand, parent.transform.position, Quaternion.identity);
                // Instantiate(Rhand, parent.transform.position, Quaternion.identity);
                // Instantiate(torsoU, parent.transform.position, Quaternion.identity);
                // Instantiate(torsoL, parent.transform.position, Quaternion.identity);
                deathParticles.SetActive(true);
                deathParticles.transform.parent = transform.parent;
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
