using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownZone : Zone
{
    public override void GetEffect(Player player)
    {
        player.GetPlayerMovementComponent().ChangeMuiltiplierSpeedValue(0.6f);
    }
}
