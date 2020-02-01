using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{

    public float health;
    public bool inputPaused;
    public static PlayerManager instance;


    public Image[] hearts;
    public int numOfHearts;

    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Awake()
    {
        inputPaused = false;
        if (instance != null)
        {
            Debug.Log("Warning, multiple players");
            return;
        }
        instance = this;
    }



    void Start()
    {
    }

    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }

        }
    }

    public void TakeDamage(float damage)
    {
        if (!FindObjectOfType<AudioManager>().IsPlaying("damage"))
        {
            FindObjectOfType<AudioManager>().Play("damage");
        }
        health -= damage;
        if (health <= 0)
        {
            // Die
        }
    }
}
