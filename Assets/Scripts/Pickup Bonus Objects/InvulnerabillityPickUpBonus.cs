using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvulnerabillityPickUpBonus : PickupBonus
{
    public override void GetThisBonus(Player player)
    {
        player.gameObject.AddComponent<InvulnerabillityBooster>();
        Destroy(gameObject);
    }
}
