﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public float health;
    public bool inputPaused;
    public static PlayerManager instance;

    void Awake()
    {
        inputPaused = false;
        if (instance != null) {
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

    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0) {
            // Die
        }
    }
}
