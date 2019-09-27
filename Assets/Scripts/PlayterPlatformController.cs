using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayterPlatformController : physticsObject
{
    public float maxSpeed = 8;
    public float jumpTakeOffSpeed = 25;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    Damageable damageable;
    bool lookRight = true;
    public GameObject attackHit;

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


        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
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
