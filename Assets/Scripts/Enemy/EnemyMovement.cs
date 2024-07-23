using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    private NavMeshAgent navMeshAgent;
    private Vector3 targetPostiion;

    private void OnEnable()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        targetPostiion = player.position;

        navMeshAgent.SetDestination(targetPostiion);
    }


}

