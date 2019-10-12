using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicPickup : MonoBehaviour
{
    [SerializeField] int magicAmount = 1;
    [SerializeField] string magicType;
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
    void Start()
    {
        Rigidbody2D rg = GetComponent<Rigidbody2D>();
        rg.AddForce(new Vector2(transform.position.x * UnityEngine.Random.Range(-10,10),transform.position.y * UnityEngine.Random.Range(50,100)));
    }
     void FixedUpdate() {
    }
}

