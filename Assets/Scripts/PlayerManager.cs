using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{

    public float health = 6;
    public bool inputPaused;
    public static PlayerManager instance;


    public Image[] hearts;
    public int numOfHearts;

    public Sprite fullHeart;
    public Sprite halfHeart;

    bool inCriticalHealth = false;

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

        if (health > 5)
        {
            inCriticalHealth = false;
            hearts[0].sprite = fullHeart;
            hearts[1].sprite = fullHeart;
            hearts[2].sprite = fullHeart;
        }
        else if (health > 4)
        {
            inCriticalHealth = false;
            hearts[0].sprite = fullHeart;
            hearts[1].sprite = fullHeart;
            hearts[2].sprite = halfHeart;
        }
        else if (health > 3)
        {
            inCriticalHealth = false;
            hearts[0].sprite = fullHeart;
            hearts[1].sprite = fullHeart;
            hearts[2].enabled = false;
        }
        else if (health > 2)
        {
            hearts[0].sprite = fullHeart;
            hearts[1].sprite = halfHeart;
            hearts[2].enabled = false;
        }
        else if (health > 1)
        {
            hearts[0].sprite = fullHeart;
            hearts[1].enabled = false;
            hearts[2].enabled = false;
        }
        else if (health > 0)
        {
            hearts[0].sprite = halfHeart;
            hearts[1].enabled = false;
            hearts[2].enabled = false;
        }
        else
        {
            hearts[0].enabled = false;
            hearts[1].enabled = false;
            hearts[2].enabled = false;
        }


    }

    public void TakeDamage(float damage)
    {
        if (!FindObjectOfType<AudioManager>().IsPlaying("damage"))
        {
            FindObjectOfType<AudioManager>().Play("damage");
        }
        health -= damage;

        if (health < 3)
        {
            inCriticalHealth = true;
            if (!FindObjectOfType<AudioManager>().IsPlaying("critical_damage"))
            {
                FindObjectOfType<AudioManager>().Play("critical_damage");
            }
        }

        if (health <= 0)
        {
            // Die
        }
    }
}
