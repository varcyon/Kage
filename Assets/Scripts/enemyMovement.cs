using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : PhysicsObject
{
    Damageable damageable;
    public float followRange = 8f;
    public float turnBackRange =5.0f;
    public float directionSmooth = 1f;
    public float direction = 1;
    public float playerDifference;
    public float changeDirectionEase = 1;
    public bool followPlayer;
    public float maxSpeed = 7;
    public int jumpTakeOffSpeed = 20;
    private RaycastHit2D ground;
    private RaycastHit2D rightWall;
    private RaycastHit2D leftWall;
    private RaycastHit2D rightLedge;
    private RaycastHit2D leftLedge;
	[SerializeField] private LayerMask layerMask;
    [SerializeField] private Vector2 rayCastOffset;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, followRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, turnBackRange);
    }
    void Start()
    {
        damageable = GetComponent<Damageable>();
    }


    protected override void ComputeVelocity()
    {

        playerDifference = Player.Instance.gameObject.transform.position.x - transform.position.x;
        directionSmooth += (direction - directionSmooth) * Time.deltaTime * changeDirectionEase;

        ground = Physics2D.Raycast(transform.position, -Vector2.up);
        Debug.DrawRay(transform.position, -Vector2.up, Color.blue);


        if ((Mathf.Abs(playerDifference) < followRange))
        {
            followPlayer = true;
        }
        else
        {
            followPlayer = false;
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
            if (playerDifference < 0)
            {
                direction = 1;
            }
            else
            {
                direction = -1;
            }
        }

        //Check for walls
        rightWall = Physics2D.Raycast(new Vector2(transform.position.x + rayCastOffset.x, transform.position.y + rayCastOffset.y), Vector2.right,turnBackRange, layerMask);
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y + rayCastOffset.y),  new Vector2(turnBackRange-1,0), Color.red);

        if (rightWall.collider != null)
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

        leftWall = Physics2D.Raycast (new Vector2 (transform.position.x - rayCastOffset.x, transform.position.y + rayCastOffset.y), Vector2.left, turnBackRange, layerMask);
			Debug.DrawRay (new Vector2 (transform.position.x, transform.position.y + rayCastOffset.y), new Vector2(-turnBackRange+1,0), Color.blue);

			if (leftWall.collider != null) {
				if (!followPlayer) {
					direction = 1;
				} else {
					Jump ();
				}
			}

        targetVelocity.x = direction * maxSpeed;
    }

    public void Jump()
    {
        if (grounded)
        {
            velocity.y = jumpTakeOffSpeed;
        }
    }
}

