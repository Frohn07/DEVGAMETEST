using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    
    private Transform targetTransform;
    private NavMeshAgent navMeshAgent;
    private Vector3 targetPostiion;


    public void Init(Transform targetTransform)
    {
        this.targetTransform = targetTransform;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }


    private void Update()
    {
        if (targetTransform != null)
        {
            targetPostiion = targetTransform.position;
            navMeshAgent.SetDestination(targetPostiion);
        }
    }


}

