using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public GameObject impactEffect;
    //public GameObject BloodEffect;

    public void TakeDamage(float amount)
    {
        health -= amount;


        // GameObject impactGO2 = Instantiate(BloodEffect, transform.position, Quaternion.identity);
        // Destroy(impactGO2, 2f);
        if (health <= 0f)
        {
            Die();


            GameObject impactGO = Instantiate(impactEffect, transform.position, Quaternion.identity);

            Destroy(impactGO, 2f);
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
