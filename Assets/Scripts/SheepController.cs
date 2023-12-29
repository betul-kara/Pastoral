using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SheepController : MonoBehaviour
{
    Transform goalPos;
    Animator animator;
    NavMeshAgent agent;
    bool walk;
    bool isSafe = false;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        goalPos = GameObject.Find("Player").transform;
    }
    void Update()
    {
        if (!isSafe)
        {
            agent.SetDestination(goalPos.position);
            //walk = agent.remainingDistance > agent.stoppingDistance ? true : false;

            if (agent.remainingDistance > agent.stoppingDistance)
            {
                animator.SetBool("walk", true);
                animator.SetBool("idle", false);
            }
            else
            {
                animator.SetBool("walk", false);
                animator.SetBool("idle", true);
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SafeZone"))
        {
            isSafe = true;
            animator.SetBool("walk", false);

            animator.SetBool("idle", true);

        }
    }

}
// tüm koyunlar güvenli alandaysa bir sonraki levele aktar
