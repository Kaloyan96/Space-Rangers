using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class UnitMotor : MonoBehaviour
{
    NavMeshAgent navAgent;
    Transform target; 

    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // If we have a target
		if (target != null)
		{
			// Move towards it and look at it
			navAgent.SetDestination(target.position);
			FaceTarget();
		}
    }

    public void MoveToPoint (Vector3 point)
	{
		navAgent.SetDestination(point);
	}

    public void FollowTarget (Interactable newTarget)
	{
		navAgent.stoppingDistance = newTarget.radius * .8f;
		navAgent.updateRotation = false;

		target = newTarget.transform;
	}

	// Stop following a target
	public void StopFollowingTarget ()
	{
		navAgent.stoppingDistance = 0f;
		navAgent.updateRotation = true;

		target = null;
	}

	// Make sure to look at the target
	void FaceTarget ()
	{
		Vector3 direction = (target.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
	}
}
