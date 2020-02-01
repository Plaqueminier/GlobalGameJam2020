using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0f)
        {
            Die();
        }

    }

    void Die()
    {
        if (gameObject.name == "Zombie")
            FindObjectOfType<AudioManager>().Play("zombie_die");
        else if (gameObject.name == "Mort")
            FindObjectOfType<AudioManager>().Play("mort_die");
        Destroy(gameObject);
    }
}
