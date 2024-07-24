using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{

    private Player parent;

    public void Init(Player player)
    {
        parent = player;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out PickupBonus pickupBonus))
        {
            pickupBonus.GetThisBonus(parent);
        }

        if(other.gameObject.TryGetComponent(out Zone zone))
        {
            zone.GetEffect(parent);
        }

        if(other.gameObject.TryGetComponent(out Enemy enemy))
        {
            parent.GetPlayerHealthComponent().TakeDamage();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out SlowDownZone slowDownZone))
        {
            parent.GetPlayerMovementComponent().ChangeMuiltiplierSpeedValue(1);
        }
    }


}
