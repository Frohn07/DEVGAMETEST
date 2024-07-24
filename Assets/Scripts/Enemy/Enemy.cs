using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    private float health;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private int rewardValue;
    [SerializeField]
    private float spawnProbability;

    //private Transform targetTransform;


    public void Init(Transform targetTrasform)
    {
        GetComponent<EnemyMovement>().Init(moveSpeed, targetTrasform);
        GetComponent<EnemyHealth>().Init(health);
    }


    public float GetHelth()
    {
        return health;
    }
    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
    public int GetRewardValue()
    {
        return rewardValue;
    }
    public float GetSpawmProbability()
    {
        return spawnProbability;
    }
}
