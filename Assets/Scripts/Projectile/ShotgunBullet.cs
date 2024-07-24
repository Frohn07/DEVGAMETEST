using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBullet : Projectile
{
    public override void StartMove()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 20, ForceMode.Impulse);
        StartCoroutine(bulletDestoyer());
    }

    private IEnumerator bulletDestoyer()
    {

        while (Vector3.Distance(transform.position, startPosition) <= flightRange)
        { 
            yield return null;
        }

        Destroy(gameObject);
    }
}
