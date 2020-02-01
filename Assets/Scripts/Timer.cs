using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private UnityEvent OnTimerEnd = new UnityEvent();
    [SerializeField]
    private float timer = 1f;
    [SerializeField]
    private bool isLoop = true;

    private bool isComplete = true;
    private float remainingTimer = 0f;

    void Start()
    {

    }

    void Update()
    {
        if (remainingTimer > 0) {
            remainingTimer -= Time.deltaTime;
        } else {
            if (isComplete == false) {
                OnTimerEnd.Invoke();
            }
            isComplete = true;
            if (isLoop) {
                isComplete = false;
                remainingTimer = timer;
            }
        }
    }
}
