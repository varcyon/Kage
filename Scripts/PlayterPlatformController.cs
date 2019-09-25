using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayterPlatformController : physticsObject
{
    // Start is called before the first frame update
    public float maxSpeed = 8;
    public float jumpTakeOffSpeed = 25;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    protected override void ComputerVelocity()
    {

        if (Input.GetButtonDown("Attack"))
        {
            animator.SetBool("Attack", true);

        }
        if (Input.GetButtonUp("Attack"))
        {
            animator.SetBool("Attack", false);
        }

        Vector2 move = Vector2.zero;
        move.x = Input.GetAxis("Horizontal");
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
        bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        animator.SetBool("Grounded", grounded);
        animator.SetFloat("VelocityX", Mathf.Abs(velocity.x / maxSpeed));
        targetVelocity = move * maxSpeed;
    }

}
