using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GrenadeBullet : Projectile
{
    [SerializeField]
    private GameObject explosionEffectPrefab;
    private Vector3 targetPosition;



    public override void StartMove()
    {
        canDamage = false;
        SetTargetPosition();
        StartCoroutine(TransformMe());
    }

    private void SetTargetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.point);
            targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
        }

    }

    private IEnumerator TransformMe()
    {
        while(transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, 0.1f);
            yield return null;
        }

        CheckEnemyAndDamageAroundExplosion();
        SpawnExplosionEffect();
        Destroy(gameObject);
    }


    private void SpawnExplosionEffect()
    {
        GameObject newExplosionEffect = Instantiate(explosionEffectPrefab, targetPosition, Quaternion.identity);
        float effectLifeTime = newExplosionEffect.GetComponent<Animator>().runtimeAnimatorController.animationClips[0].length;
        Destroy(newExplosionEffect, effectLifeTime);
    }

    private void CheckEnemyAndDamageAroundExplosion()
    {

        RaycastHit[] hits = Physics.SphereCastAll(targetPosition, 2, Vector3.up);

        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].transform.gameObject.TryGetComponent(out EnemyHealth enemyHealth))
            {
                enemyHealth.TakeDamage(damage);

            }
            //Debug.Log("hits: " + hits[i].transform.gameObject.name);
        }

    }
}
