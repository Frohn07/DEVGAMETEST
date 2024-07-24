using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBonus : PickupBonus
{
    [SerializeField]
    private Weapon weaponPrefab;

    public override void GetThisBonus(Player player)
    {
        if (player == null)
            Debug.Log("null");

        player.GetPlayerAttackComponent().ChangeWeapon(weaponPrefab);

        Destroy(gameObject);
    }

    public Weapon GetMyWeapon()
    {
        return weaponPrefab;
    }
}
