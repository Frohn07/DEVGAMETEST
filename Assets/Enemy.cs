using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    private int healt;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private int rewardValue;
    [SerializeField]
    private float spawnProbability;


    public int GetHelth()
    {
        return healt;
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
