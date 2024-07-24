using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField]
    private float damage;
    [SerializeField]
    protected float flightRange;

    protected Vector3 startPosition;

    protected float speed = 5;


    public void Init(float damage ,float flightRange, Vector3 weaponNuzzlePosition)
    {
        this.damage = damage;
        this.flightRange = flightRange;
        startPosition = weaponNuzzlePosition;
    }

    public abstract void StartMove();
   
    /*
    public virtual void CheckFlightRange()
    {
        if (flightRange == -1)
        {
            Destroy(gameObject, 20);
            return;
        }
    }


    private IEnumerator checkBulletDistance()
    {
        while(Vector3.Distance(transform.position, startPosition) < flightRange)
        {
            yield return null;
        }

        Destroy(gameObject);
    }
    */
}
