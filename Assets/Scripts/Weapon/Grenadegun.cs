using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenadegun : Weapon
{
    public override void Shoot()
    {
       
        Projectile newProjectile = Instantiate(projectilePrefab, nuzzle.position, nuzzle.rotation);
        newProjectile.Init(damage, projectileflightRange, nuzzle.position);
        newProjectile.StartMove();
    }

}
