using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerHealth playerHealth;
    private PlayerMovement playerMovement;
    private PlayerAttack playerAttack;
    private PlayerTrigger playerTrigger;


    public void Init()
    {
        playerAttack = GetComponent<PlayerAttack>();
        playerMovement = GetComponent<PlayerMovement>();
        playerHealth = GetComponent<PlayerHealth>();
        playerTrigger = GetComponent<PlayerTrigger>();

        playerTrigger.Init(this);
    }


    public PlayerAttack GetPlayerAttackComponent()
    {
        return playerAttack;
    }
    public PlayerMovement GetPlayerMovementComponent()
    {
        return playerMovement;
    }
    public PlayerHealth GetPlayerHealthComponent()
    {
        return playerHealth;
    }
}

