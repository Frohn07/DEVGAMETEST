using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBooster : Booster
{
    private PlayerMovement playerMovement;

    private float speedIncrement = 1.5f;

    private void OnEnable()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerMovement.ChangeIncrementSpeedValue(speedIncrement);

        Invoke(nameof(DestroyMe), lifetime);
    }

    private void DestroyMe()
    {
        playerMovement.ChangeIncrementSpeedValue(-speedIncrement);
        Destroy(this);
    }

}
