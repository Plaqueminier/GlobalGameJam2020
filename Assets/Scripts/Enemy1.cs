using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class Enemy1 : Enemy
{

    NavMeshAgent agent;
    NavMeshObstacle obstacle;
    PlayerManager player;
    public float attackRadius = 10f;
    public float lookRadius = 20f;
    public Animator animator;
    public GameObject ennemy;
    public Sound mort_run;
    public Sound mort_scream;
    public Sound mort_attaque;
    public Sound mort_die;
    EnemyCombat enemyCombat;
    bool scream = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemyCombat = GetComponent<EnemyCombat>();
        player = PlayerManager.instance;
        agent.stoppingDistance = attackRadius - 0.1f;
        agent.avoidancePriority = UnityEngine.Random.Range(0, 10);
        setSounds();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        bool isRunning = false;
        bool isAttacking = false;
        if (distance <= lookRadius)
        {
            if (!scream)
            {
                mort_scream.source.Play();
                scream = true;
            }
            agent.SetDestination(player.transform.position);
            if (distance <= attackRadius)
            {
                isAttacking = true;
                animator.SetBool("isRunning", isRunning);
                animator.SetBool("isAttacking", isAttacking);
                enemyCombat.Attack(this, player);
            }
            else
            {
                isRunning = true;
                animator.SetBool("isRunning", isRunning);
                animator.SetBool("isAttacking", isAttacking);
            }
        }
        else
        {
            scream = false;
        }
        if (isRunning && !isAttacking)
        {
            if (!mort_run.source.isPlaying)
            {
                mort_run.source.Play();
            }
        }
        else if (isAttacking)
        {
            // if (mort_grrr.source.isPlaying)
            // {
            //     mort_grrr.source.Play();
            // }

            // if (mort_run.source.isPlaying)
            // {
            //     mort_run.source.Stop();
            // }

            if (!mort_attaque.source.isPlaying)
            {
                mort_attaque.source.Play();
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


    void setSounds()
    {
        mort_run = FindObjectOfType<AudioManager>().getAudio("mort_run");
        mort_scream = FindObjectOfType<AudioManager>().getAudio("mort_scream");
        mort_attaque = FindObjectOfType<AudioManager>().getAudio("mort_attaque");
        mort_die = FindObjectOfType<AudioManager>().getAudio("mort_die");
    }
}
