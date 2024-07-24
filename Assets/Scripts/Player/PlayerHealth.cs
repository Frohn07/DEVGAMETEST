using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private float health = 1;

    public delegate void PlayerHealthIsOverDelegate();
    public static event PlayerHealthIsOverDelegate PlayerHealthIsOverEvent;

    private bool isInvulnerable = false;


    public void TakeDamage()
    {
        if (isInvulnerable)
            return;

        health--;

        if(health >= 0)
        {
            if (PlayerHealthIsOverEvent != null)
                PlayerHealthIsOverEvent();

            Debug.Log("game over");
        }
    }

    public void ChangeInvulnerableState(bool newState)
    {
        isInvulnerable = newState;
    }
}
