using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : Zone
{
    public override void GetEffect(Player player)
    {
        player.GetPlayerHealthComponent().ChangeInvulnerableState(false);
        player.GetPlayerHealthComponent().TakeDamage();
    }
}
