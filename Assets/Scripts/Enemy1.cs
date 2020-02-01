using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class Enemy1 : MonoBehaviour
{

    NavMeshAgent agent;
    NavMeshObstacle obstacle;
    PlayerManager player;
    public float attackRadius = 10f;
    public float lookRadius = 20f;
    public Animator animator;
    public GameObject ennemy;
    public Sound zombie_grrr;
    public Sound zombie_run;
    public Sound zombie_scream;
    public Sound zombie_attaque;
    public Sound zombie_die;
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
                zombie_scream.source.Play();
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
        if (!isRunning && !isAttacking && !zombie_grrr.source.isPlaying)
        {
            Debug.Log(ennemy);
            zombie_grrr.source.Play();
        }
        else if (isRunning && !isAttacking)
        {
            // if (zombie_grrr.source.isPlaying)
            // {
            //     zombie_grrr.source.Stop();
            // }
            if (!zombie_run.source.isPlaying)
            {
                zombie_run.source.Play();
            }
        }
        else if (isAttacking)
        {
            // if (zombie_grrr.source.isPlaying)
            // {
            //     zombie_grrr.source.Play();
            // }

            // if (zombie_run.source.isPlaying)
            // {
            //     zombie_run.source.Stop();
            // }

            if (!zombie_attaque.source.isPlaying)
            {
                zombie_attaque.source.Play();
            }

            //zombie_attaque
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
        zombie_grrr = FindObjectOfType<AudioManager>().getAudio("zombie_grrr");
        zombie_run = FindObjectOfType<AudioManager>().getAudio("zombie_run");
        zombie_scream = FindObjectOfType<AudioManager>().getAudio("zombie_scream");
        zombie_attaque = FindObjectOfType<AudioManager>().getAudio("zombie_attaque");
        zombie_die = FindObjectOfType<AudioManager>().getAudio("zombie_die");
    }
}
