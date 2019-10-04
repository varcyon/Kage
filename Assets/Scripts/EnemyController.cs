using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : PhysicsObject
{
    [SerializeField] enum EnemyType { Walker, Aggressive };
    [SerializeField] EnemyType enemyType;
    Damageable damageable;
    [SerializeField] float followRange = 8f;
    [SerializeField] float turnBackRange = 5.0f;
    [SerializeField] float ledgeDetectionDepth = 3f;
    [SerializeField] float ledgeDetectionWidth = 2f;
    float directionSmooth = 1f;
    float direction = 1;
    float playerDifference;
    float changeDirectionEase = 2f;
    bool followPlayer;
    [SerializeField] float maxSpeed = 7;
    [SerializeField] int jumpTakeOffSpeed = 20;
    RaycastHit2D ground;
    RaycastHit2D rightWall;
    RaycastHit2D leftWall;
    RaycastHit2D rightLedge;
    RaycastHit2D leftLedge;
    [SerializeField] LayerMask groundLayerMask;



    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, followRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, turnBackRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector2(ledgeDetectionWidth * 2, ledgeDetectionDepth * 2));
    }
    void Start()
    {
        damageable = GetComponent<Damageable>();
    }


    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;
        playerDifference = Player.Instance.gameObject.transform.position.x - transform.position.x;
        directionSmooth += (direction - directionSmooth) * Time.deltaTime * changeDirectionEase;
        if (true)
        {
            move.x = 1 * directionSmooth;
            ground = Physics2D.Raycast(transform.position, new Vector2(0, -1), 2.2f, groundLayerMask);
            Debug.DrawRay(transform.position, new Vector2(0, -2.2f), Color.blue);
            if (enemyType == EnemyType.Aggressive)
            {
                if ((Mathf.Abs(playerDifference) < followRange))
                {
                    followPlayer = true;
                }
                else
                {
                    followPlayer = false;
                }
            }



            if (followPlayer)
            {
                if (playerDifference < 0)
                {
                    direction = -1;
                }
                else
                {
                    direction = 1;
                }
            }
            else
            {
                directionSmooth = -direction;
            }

            //Check for walls
            rightWall = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.right, turnBackRange, groundLayerMask);
            Debug.DrawRay(new Vector2(transform.position.x, transform.position.y), new Vector2(turnBackRange, 0), Color.red);

            if (rightWall.collider != null)
            {
                if (!followPlayer)
                {
                    direction = 1;
                }
                else
                {
                    Jump();
                }

            }

            leftWall = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.left, turnBackRange, groundLayerMask);
            Debug.DrawRay(new Vector2(transform.position.x, transform.position.y), new Vector2(-turnBackRange, 0), Color.blue);

            if (leftWall.collider != null)
            {
                if (!followPlayer)
                {
                    direction = -1;
                }
                else
                {
                    Jump();
                }
            }


            //Check for ledges
            if (!followPlayer)
            {
                rightLedge = Physics2D.Raycast(new Vector2(transform.position.x + ledgeDetectionWidth, transform.position.y), Vector2.down, ledgeDetectionDepth);
                Debug.DrawRay(new Vector2(transform.position.x + ledgeDetectionWidth, transform.position.y), new Vector2(0, -ledgeDetectionDepth), Color.blue);
                if (rightLedge.collider == null)
                {
                    direction = 1;
                }

                leftLedge = Physics2D.Raycast(new Vector2(transform.position.x - ledgeDetectionWidth, transform.position.y), Vector2.down, ledgeDetectionDepth);
                Debug.DrawRay(new Vector2(transform.position.x - ledgeDetectionWidth, transform.position.y), new Vector2(0, -ledgeDetectionDepth), Color.blue);

                if (leftLedge.collider == null)
                {
                    direction = -1;
                }
            }
            targetVelocity = move * maxSpeed;

        }
        

    }
    public void Jump()
        {
            if (grounded)
            {
                velocity.y = jumpTakeOffSpeed;
            }
        }
}



