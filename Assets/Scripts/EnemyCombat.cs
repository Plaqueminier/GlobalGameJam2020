using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public float damage = 10f;
    public float attackSpeed = 1f;
    private float attackCooldown = 0f;
    public float attackDelay = 1f;
    PlayerManager player;

    void Start()
    {
        player = PlayerManager.instance;
    }

    public void Update()
    {
        attackCooldown -= Time.deltaTime;
    }

    public void Attack()
    {
        if (attackCooldown <= 0f) {
            StartCoroutine("DoDamage", attackDelay);
            attackCooldown = 1f / attackSpeed;
        }
    }

    IEnumerator DoDamage(float delay)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("Player take damage");
        player.TakeDamage(damage);
    }
}
