using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickupBonus : MonoBehaviour
{
    protected float lifeTime = 5f;

    private void OnEnable()
    {
        Destroy(gameObject, lifeTime);
    }

    public abstract void GetThisBonus(Player player);

}
