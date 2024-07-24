using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvulnerabillityBooster : Booster
{
    private PlayerHealth playerHealth;
   

    private void OnEnable()
    {
        playerHealth = GetComponent<PlayerHealth>();
        playerHealth.ChangeInvulnerableState(true);

        Invoke(nameof(DestroyMe), lifetime);
    }

    private void DestroyMe()
    {
        playerHealth.ChangeInvulnerableState(false);
        Destroy(this);
    }
}
