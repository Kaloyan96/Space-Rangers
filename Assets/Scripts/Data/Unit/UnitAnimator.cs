using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitAnimator : MonoBehaviour
{
    const float locomotionAnimationSmoothTime = .1f;
    NavMeshAgent agent;
    Animator animator;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float speedPercent = agent.velocity.magnitude / agent.speed;
        //Debug.Log(speedPercent);
        animator.SetFloat("speedPercent", speedPercent, locomotionAnimationSmoothTime, Time.deltaTime);
        //animator.SetFloat("speedPercent", speedPercent);
    }
}
