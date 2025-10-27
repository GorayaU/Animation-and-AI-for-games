using System;
using UnityEngine;
using UnityEngine.AI;

public class NavControl2 : MonoBehaviour
{
    public GameObject target;
    private NavMeshAgent _agent;
    
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        _agent.SetDestination(target.transform.position);
    }
}