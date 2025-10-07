using System;
using System.Collections.Generic;
using UnityEngine;

public class PathController : MonoBehaviour
{
    [SerializeField] public PathManager pathManager;

    private List<WayPoint> thePath;
    private WayPoint target;

    public float moveSpeed;
    public float rotateSpeed;
    public Animator animator;
    
    private bool isWalking;

    private void Start()
    {
        thePath = pathManager.GetPath();
        if (thePath != null && thePath.Count > 0)
        {
            target = thePath[0];
        }

        isWalking = false;
        animator.SetBool("isWalking", isWalking);
    }
    
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            isWalking = !isWalking;
            animator.SetBool("isWalking", isWalking);
        }
        if (isWalking)
        {
            rotateTowardsTarget();
            moveForward();
        }
    }

    void rotateTowardsTarget()
    {
        float stepSize = rotateSpeed * Time.deltaTime;
        
        Vector3 targetDir = target.pos - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, stepSize, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);
    }

    void moveForward()
    {
        float stepSize = moveSpeed * Time.deltaTime;
        float distanceToTarget = Vector3.Distance(transform.position, target.pos);
        if (distanceToTarget < stepSize)
        {
            return;
        }

        Vector3 moveDir = Vector3.forward;
        transform.Translate(moveDir * stepSize);
    }

    private void OnTriggerEnter(Collider other)
    {
        target = pathManager.getNextTarget();
    }
}
