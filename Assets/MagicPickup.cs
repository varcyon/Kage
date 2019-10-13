using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicPickup : MonoBehaviour
{
    [SerializeField] int magicAmount = 1;
    [SerializeField] string magicType;
   [SerializeField] float chasePlayer =10f;
   [SerializeField] int chaseSpeed = 30;
    void OnTriggerEnter2D(Collider2D other)
    {
        Magic magic = other.GetComponent<Magic>();

        if (magic != null)
        {
            magicType = gameObject.name;
            switch (magicType)
            {
                case "PurgatoryWater(Clone)":
                    magic.PurgatoryWater += magicAmount;
                    break;
                case "HellFire(Clone)":
                    magic.HellFire += magicAmount;
                    break;
                case "HeavenMetal(Clone)":
                    magic.HeavenMetal += magicAmount;
                    break;
                default:
                    break;
            }

            Destroy(gameObject);
        }
    }

     void FixedUpdate() {
        if((Player.Instance.gameObject.transform.position.x - transform.position.x) < chasePlayer){
            transform.position = Vector3.MoveTowards(transform.position, Player.Instance.gameObject.transform.position, Time.deltaTime * chaseSpeed);
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, chasePlayer);
        
    }
}

