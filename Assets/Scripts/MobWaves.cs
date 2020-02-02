using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobWaves : MonoBehaviour
{
    public List<GameObject> wave1 = new List<GameObject>();
    public List<GameObject> wave2 = new List<GameObject>();
    public List<GameObject> wave3 = new List<GameObject>();
    bool isTriggered;
    private int waveNb;
    int wave1Size;
    int wave2Size;
    int wave3Size;
    public DialogueSystem dialogueSystem;

    void Start()
    {
        isTriggered = false;
        waveNb = 0;
        wave1Size = wave1.Count;
        wave2Size = wave2.Count;
        wave3Size = wave3.Count;
        dialogueSystem.playNextReply();
        StartCoroutine("LateStart");
    }

    IEnumerator LateStart()
    {
        yield return new WaitForSeconds(0.1f);
        dialogueSystem.playNextReply();
    }

    void Update()
    {
        int i = 0;
        if (waveNb == 1)
        {
            foreach (GameObject mob in wave1)
            {
                if (!mob)
                    i += 1;
            }
            if (i == wave1Size)
                launchWave2();
        }
        else if (waveNb == 2)
        {
            foreach (GameObject mob in wave2)
            {
                if (!mob)
                    i += 1;
            }
            if (i == wave2Size)
            {
                waveNb += 1;
                launchWave3();
            }
        }
        else if (waveNb == 3)
        {
            foreach (GameObject mob in wave3)
            {
                if (!mob)
                    i += 1;
            }
            if (i == wave3Size)
            {
                Debug.Log("FINI");

                if (!FindObjectOfType<AudioManager>().IsPlaying("victory"))
                {
                    FindObjectOfType<AudioManager>().Play("victory");
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        launchWave1();
    }

    void launchWave1()
    {
        waveNb += 1;
        dialogueSystem.playNextReply();
        foreach (GameObject mob in wave1)
        {
            mob.SetActive(true);
        }
    }

    void launchWave2()
    {
        waveNb += 1;
        dialogueSystem.playNextReply();
        foreach (GameObject mob in wave2)
        {
            mob.SetActive(true);
        }
    }

    void launchWave3()
    {
        waveNb += 1;
        dialogueSystem.playNextReply();
        foreach (GameObject mob in wave3)
        {
            mob.SetActive(true);
        }
    }
}
