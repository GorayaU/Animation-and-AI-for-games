using System;
using UnityEngine;
using UnityEngine.AI;

public class NavControl : MonoBehaviour
{
    public GameObject target;
    private NavMeshAgent _agent;
    private bool _isWalking;
    private Animator _animator;


    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();

        _isWalking = true;
    }

    void Update()
    {
        if (_isWalking)
        {
            _agent.SetDestination(target.transform.position);
        }
        else
        {
            _agent.destination = transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Green")
        {
            _isWalking = false;
            _animator.SetTrigger("Attack");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Green")
        {
            _isWalking = true;
            _animator.SetTrigger("Walk");
        }
    }
}