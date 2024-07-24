using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private float health = 1;

    public void Init(float health)
    {
        this.health = health;
    }

    public void TakeDamage(float inputDamage)
    {
        health-= inputDamage;
        if (health <= 0)
        {
            HealthIsOver();
        }
    }

    private void HealthIsOver()
    {
        GameParametersManager.currentScore += GetComponent<Enemy>().GetRewardValue();
        Destroy(gameObject);
    }
}
