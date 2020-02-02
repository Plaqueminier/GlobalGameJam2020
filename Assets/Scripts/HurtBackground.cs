using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBackground : MonoBehaviour
{
    CanvasGroup canvasGroup;
    public float maxAlpha = 1f;
    public float step = 0.3f;
    public bool isSuffering;
    public float stepDelay;
    public float speed = 2f;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        isSuffering = false;
    }

    void Update()
    {
        // if (Input.GetButtonDown("Jump"))
        //     GetComponent<HurtBackground>().increaseDark();
        if (isSuffering && canvasGroup.alpha < maxAlpha && stepDelay > 0) {
            canvasGroup.alpha += speed * Time.deltaTime;
            stepDelay -= speed * Time.deltaTime;
        } else {
            isSuffering = false;
        }
    }

    public void increaseDark()
    {
        stepDelay = step;
        isSuffering = true;
    }
}
