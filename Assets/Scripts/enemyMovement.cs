using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : physticsObject
{
    Damageable damageable;
    // Start is called before the first frame update
    void Start()
    {
        damageable = GetComponent<Damageable>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    protected override void ComputerVelocity()
    {
                damageable.launch += (0 - damageable.launch) * Time.deltaTime * damageable.launchRecovery;

    }
}
