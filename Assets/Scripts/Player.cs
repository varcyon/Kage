using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : physticsObject
{
    public float maxSpeed = 8;
    public float jumpTakeOffSpeed = 25;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    Damageable damageable;
    bool lookRight = true;
    public GameObject attackHit;
    int numOfJumps = 0;
    int maxJumps = 2;
    private static Player instance;
    public static Player Instance
    {
        get
        {
            if (instance == null) instance = GameObject.FindObjectOfType<Player>();
            return instance;
        }
    }
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        damageable = GetComponent<Damageable>();
    }

    protected override void ComputerVelocity()
    {

        Vector2 move = Vector2.zero;
        damageable.launch += (0 - damageable.launch) * Time.deltaTime * damageable.launchRecovery;
        move.x = Input.GetAxis("Horizontal");
        if (move.x > 0f && !lookRight || move.x < 0f && lookRight)
        {
            lookRight = !lookRight;
            Vector3 charscale = transform.localScale;
            charscale.x *= -1;
            transform.localScale = charscale;
        }


        if (Input.GetButtonDown("Jump"))
        {
            if (grounded) { numOfJumps = 0; }
            if (grounded || numOfJumps < maxJumps)
            {
                velocity.y = 0;
                velocity.y = jumpTakeOffSpeed;
                numOfJumps += 1;
            }
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * .5f;
            }
        }


        if (Input.GetButtonDown("Attack"))
        {
            animator.SetTrigger("Attack");
        }


        animator.SetBool("Grounded", grounded);
        animator.SetFloat("VelocityX", Mathf.Abs(velocity.x / maxSpeed));
        targetVelocity = move * maxSpeed;
    }

}
