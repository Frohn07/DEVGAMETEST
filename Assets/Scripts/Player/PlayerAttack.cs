using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private Weapon currentWeapon;
    [SerializeField]
    private Transform weaponPoint;

    private float elaptedTime = 0;
    private float shootCooldown;

    private bool canShoot = true;


    public void Init()
    {
        
    }

    void Update()
    {
        if (!canShoot)
            return;

        if (Input.GetMouseButton(0))
        {
            shootCooldown = 1f / currentWeapon.GetShootSpeed();

            elaptedTime += Time.deltaTime;

            if(elaptedTime >= shootCooldown)
            {
                elaptedTime = 0;
                Shoot();
            }

   
        }
        if (Input.GetMouseButtonUp(0))
        {
            elaptedTime = 0;
        }

    }
   

    private void Shoot()
    {
        if (currentWeapon != null)
            currentWeapon.Shoot();
    }



    public void ChangeWeapon(Weapon newWeapon)
    {
        canShoot = false;

        Destroy(currentWeapon.gameObject);

        currentWeapon = Instantiate(newWeapon, weaponPoint.position, transform.rotation, weaponPoint);

        canShoot = true;
    }

    public Weapon GetMyActiveWeapon()
    {
        return currentWeapon;
    }

}
