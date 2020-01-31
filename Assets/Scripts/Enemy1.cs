using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy1 : MonoBehaviour
{

    NavMeshAgent agent;
    PlayerManager player;
    public float attackRadius = 10f;
    public Animator animator;

    [SerializeField]
    bool isRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = PlayerManager.instance;
        agent.stoppingDistance = attackRadius;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        agent.SetDestination(player.transform.position);
        Debug.Log(distance);
        if (distance <= attackRadius) {
            animator.SetBool("isRunning", false);
            animator.SetBool("isAttacking", true);
            isRunning = false;
        } else {
            animator.SetBool("isRunning", true);
            animator.SetBool("isAttacking", false);
            isRunning = true;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
