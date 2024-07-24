using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBullet : Projectile
{
    public override void StartMove()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 20, ForceMode.Impulse);

        Debug.Log("flightRange: " + flightRange);
        StartCoroutine(bulletDestoyer());
        Debug.Log("flightRange1: " + flightRange);
    }

    private IEnumerator bulletDestoyer()
    {
        Debug.Log("flightRange: " + flightRange);

        while (Vector3.Distance(transform.position, startPosition) <= flightRange)
        {
            Debug.Log("Distance: " + Vector3.Distance(transform.position, startPosition));
            Debug.Log("flightRange: " + flightRange);

            yield return null;
        }

        Destroy(gameObject);
    }
}
