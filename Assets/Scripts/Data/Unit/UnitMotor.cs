using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class UnitMotor : MonoBehaviour
{
    public NavMeshAgent NavAgent { get; private set; }
    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        NavAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // If we have a target
        if (target != null)
        {
            // Move towards it and look at it
            NavAgent.SetDestination(target.position);
            faceTarget();
        }
    }

    public void moveToPoint(Vector3 point)
    {
        NavAgent.SetDestination(point);
    }

    public void followTarget(Interactable newTarget)
    {
        NavAgent.stoppingDistance = newTarget.InteractionRange;
        NavAgent.updateRotation = false;

        target = newTarget.InteractionSource;
    }

    // Stop following a target
    public void stopFollowingTarget()
    {
        NavAgent.stoppingDistance = 0f;
        NavAgent.updateRotation = true;

        stop();
    }

    public void stop()
    {
        target = null;
    }

    // Make sure to look at the target
    void faceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
