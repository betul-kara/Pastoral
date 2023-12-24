using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SheepController : MonoBehaviour
{
    [SerializeField] Transform goalPos;
    Animator animator;
    NavMeshAgent agent;
    bool walk;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        agent.SetDestination(goalPos.position);
        walk = agent.remainingDistance > agent.stoppingDistance ? true : false;
        animator.SetBool("walk", walk);
    }
}
