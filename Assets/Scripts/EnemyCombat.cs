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

    public void Attack(Enemy1 enemy, PlayerManager player)
    {
        if (attackCooldown <= 0f) {
            StartCoroutine(DoDamage(attackDelay, enemy, player));
            attackCooldown = 1f / attackSpeed;
        }
    }

    IEnumerator DoDamage(float delay, Enemy1 enemy, PlayerManager player)
    {
        yield return new WaitForSeconds(delay);
        float distance = Vector3.Distance(enemy.transform.position, player.transform.position);
        if (distance <= enemy.attackRadius) {
            Debug.Log("Player take damage");
            player.TakeDamage(damage);
        } else {
            Debug.Log("Player went too far to be attacked");
        }
    }
}
