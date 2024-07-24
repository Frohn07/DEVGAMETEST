using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultBullet : Projectile
{

    private float lifeTime = 20f;

    public override void StartMove()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 20, ForceMode.Impulse);

        if(flightRange == -1)
        {
            Destroy(gameObject, lifeTime);
        }
    }
}
