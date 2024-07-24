using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPickupBonus : PickupBonus
{

    public override void GetThisBonus(Player player)
    {
        player.gameObject.AddComponent<SpeedBooster>();
        Destroy(gameObject);
    }
}
