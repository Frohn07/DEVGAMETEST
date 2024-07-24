using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField]
    protected float damage;
    [SerializeField]
    protected float shootSpeed;
    [SerializeField]
    protected float projectileflightRange;
    [SerializeField]
    protected Projectile projectilePrefab;
    [SerializeField]
    protected Transform nuzzle;


    public abstract void Shoot();

    public float GetDamage()
    {
        return damage;
    }
    public float GetShootSpeed()
    {
        return shootSpeed;
    }
   
}
