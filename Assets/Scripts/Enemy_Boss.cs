using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class Enemy_Boss : Enemy
{

    NavMeshAgent agent;
    NavMeshObstacle obstacle;
    PlayerManager player;
    public float lookRadius = 20f;
    public Animator animator;
    public GameObject ennemy;
    public Sound boss_run;
    public Sound boss_scream;
    public Sound boss_attaque;
    public Sound boss_die;
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
                boss_scream.source.Play();
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
        if (!isRunning && !isAttacking)
        {
            Debug.Log(ennemy);
        }
        else if (isRunning && !isAttacking)
        {
            if (!boss_run.source.isPlaying)
            {
                boss_run.source.Play();
            }
        }
        else if (isAttacking)
        {

            if (!boss_attaque.source.isPlaying)
            {
                boss_attaque.source.Play();
            }

            //boss_attaque
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
        boss_run = FindObjectOfType<AudioManager>().getAudio("boss_run");
        boss_scream = FindObjectOfType<AudioManager>().getAudio("boss_scream");
        boss_attaque = FindObjectOfType<AudioManager>().getAudio("boss_attaque");
        boss_die = FindObjectOfType<AudioManager>().getAudio("boss_die");
    }
}
