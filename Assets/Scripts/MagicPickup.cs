using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicPickup : MonoBehaviour
{
    [SerializeField] int magicAmount = 1;
    [SerializeField] string magicType;
    [SerializeField] float chasePlayer = 10f;
    [SerializeField] int chaseSpeed = 30;
    [SerializeField] bool isHealth;
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            magicType = gameObject.name;
            switch (magicType)
            {
                case "PurgatoryWater(Clone)":
                    Magic.Instance.PurgatoryWater += magicAmount;
                    break;
                case "HellFire(Clone)":
                    Magic.Instance.HellFire += magicAmount;
                    break;
                case "HeavenMetal(Clone)":
                    Magic.Instance.HeavenMetal += magicAmount;
                    break;
                default:
                    break;
            }

            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (isHealth)
        {
            if (Player.Instance.GetComponent<Damageable>().health < Player.Instance.GetComponent<Damageable>().maxHealth)
            {
                if ((Player.Instance.gameObject.transform.position.x - transform.position.x) < chasePlayer)
                {
                    transform.position = Vector3.MoveTowards(transform.position, Player.Instance.gameObject.transform.position, Time.deltaTime * chaseSpeed);
                }
            }
        }
        if (!isHealth)
        {
            if ((Player.Instance.gameObject.transform.position.x - transform.position.x) < chasePlayer)
            {
                transform.position = Vector3.MoveTowards(transform.position, Player.Instance.gameObject.transform.position, Time.deltaTime * chaseSpeed);
            }
        }

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, chasePlayer);

    }
}

