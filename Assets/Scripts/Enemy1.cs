using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy1 : MonoBehaviour
{

    NavMeshAgent agent;
    NavMeshObstacle obstacle;
    PlayerManager player;
    public float attackRadius = 10f;
    public float lookRadius = 20f;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        obstacle = GetComponent<NavMeshObstacle>();
        player = PlayerManager.instance;
        agent.stoppingDistance = attackRadius - 0.1f;
        agent.avoidancePriority = Random.Range(0, 10);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        bool isRunning = false;
        bool isAttacking = false;
        if (distance <= lookRadius) {
            agent.SetDestination(player.transform.position);
            if (distance <= attackRadius) {
                isAttacking = true;
                animator.SetBool("isRunning", isRunning);
                animator.SetBool("isAttacking", isAttacking);
                // agent.enabled = false;
                // obstacle.enabled = true;
            } else {
                isRunning = true;
                animator.SetBool("isRunning", isRunning);
                animator.SetBool("isAttacking", isAttacking);
                // agent.enabled = true;
                // obstacle.enabled = false;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
