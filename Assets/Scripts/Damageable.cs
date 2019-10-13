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
    [SerializeField] GameObject healthContainer;


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
        int HealthMagic = UnityEngine.Random.Range(0,2);
        for (int i = 0; i < PWamount; i++)
        {
            Instantiate(purgatoryWaterFragment, new Vector2(transform.position.x + UnityEngine.Random.Range(-10, 10), transform.position.y + UnityEngine.Random.Range(0, 10)), Quaternion.identity);
        }
        for (int i = 0; i < HFamount; i++)
        {
            Instantiate(hellFireFragment, new Vector2(transform.position.x + UnityEngine.Random.Range(-10, 10), transform.position.y + UnityEngine.Random.Range(0, 10)), Quaternion.identity);
        }
        for (int i = 0; i < HMamount; i++)
        {
            Instantiate(heavenMetalFragment, new Vector2(transform.position.x + UnityEngine.Random.Range(-10, 10), transform.position.y + UnityEngine.Random.Range(0, 10)), Quaternion.identity);
        }
        for (int i = 0; i < HealthMagic; i++)
        {
            Instantiate(healthContainer, new Vector2(transform.position.x + UnityEngine.Random.Range(-10, 10), transform.position.y + UnityEngine.Random.Range(0, 10)), Quaternion.identity);
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
               StartCoroutine( PlayerDeath());
            }
            else
            {
                Die();
            }
        }
    }
    IEnumerator PlayerDeath()
    {
        parent.GetComponent<SpriteRenderer>().enabled = false;
        parent.GetComponent<Player>().enabled = false;
        deathParticles.SetActive(true);
        deathParticles.transform.parent = transform.parent;
        yield return new WaitForSeconds(5f);
        AppCommands.Instance.resetLevel();
        // currentHealth = maxHealth;
        // parent.transform.position = AppCommands.Instance.playerStart.position;
        // parent.GetComponent<SpriteRenderer>().enabled = true;
        // parent.GetComponent<Player>().enabled = true;
        // deathParticles.SetActive(false);
        // deathParticles.transform.parent = parent.transform;
        
    }
    public void increaseHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}
