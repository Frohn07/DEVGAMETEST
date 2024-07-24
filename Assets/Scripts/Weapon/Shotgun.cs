using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    private int projectileCount = 5;

    public override void Shoot()
    {
        for(int i = 0; i < projectileCount; i++)
        {
            Quaternion rotation = Quaternion.Euler(0, Random.Range(-10, 10), 0) * nuzzle.rotation;
            Projectile newProjectile = Instantiate(projectilePrefab, nuzzle.position, rotation);
            newProjectile.Init(damage, projectileflightRange, nuzzle.position);
            newProjectile.StartMove();

        }

    }
}
