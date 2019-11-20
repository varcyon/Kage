using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    [SerializeField] float speed;
    public Vector3 acceleration;
    public bool goRight;
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move();
    }

    void move()
    {
        if (goRight)
        {
            acceleration = transform.right;

        }
        else
        {
            acceleration = -transform.right;

        }

        transform.position += acceleration * speed * Time.deltaTime;
    }

}


