using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : PhysicsObject
{
    //PlayerControls controls;
    //Vector2 move = new Vector2();
    public float maxSpeed = 8;
    public float jumpTakeOffSpeed = 25;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    Magic magic;
    Damageable damageable;
    bool lookRight = true;
    public GameObject attackHit;
    int numOfJumps = 0;
    int maxJumps = 2;
    public CameraEffects cameraEffect;



    public static Player Instance { get; set; }
    void MakeSingleton()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Awake()
    {
        // controls = new PlayerControls();
        // controls.GamePlay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        // controls.GamePlay.Move.canceled += ctx => move = Vector2.zero;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        damageable = GetComponent<Damageable>();
        magic = GetComponent<Magic>();
        MakeSingleton();
    }

    // void OnEnable()
    // {
    //     controls.GamePlay.Enable();
    // }

    // void OnDisable()
    // {
    //     controls.GamePlay.Disable();
    // }
    protected override void ComputeVelocity()
    {

        //////Movements
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");
        if (move.x > 0f && !lookRight || move.x < 0f && lookRight)
        {
            lookRight = !lookRight;
            Vector3 charscale = transform.localScale;
            charscale.x *= -1;
            transform.localScale = charscale;
        }
        targetVelocity = move * maxSpeed;

        ////// Jump
        if (Input.GetButtonDown("Jump"))
        {
            if (grounded) { numOfJumps = 0; }
            if (grounded || numOfJumps < maxJumps)
            {
                if (!grounded) { animator.Play("JumpHold", -1, 0f); }
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



        ///// Attacks
        if (Input.GetButtonDown("Attack"))
        {
            animator.SetTrigger("Attack");
        }
        if (Input.GetButtonDown("HeavyAttack"))
        {
            animator.SetTrigger("HeavyAttack");
        }
        if (Input.GetButtonDown("Ranged"))
        {
            animator.SetTrigger("Ranged");
        }

        ////// Animation
        animator.SetBool("Grounded", grounded);
        animator.SetFloat("VelocityX", Mathf.Abs(velocity.x / maxSpeed));
        
    }
}
