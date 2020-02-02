using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobWaves : MonoBehaviour
{
    public List<GameObject> wave1 = new List<GameObject>();
    public List<GameObject> wave2 = new List<GameObject>();
    public List<GameObject> wave3 = new List<GameObject>();
    public AudioSource wave1audio;
    public AudioSource wave2audio;
    public AudioSource wave3audio;
    bool isTriggered;
    private int waveNb;
    int wave1Size;
    int wave2Size;
    int wave3Size;
    bool bossKilled;
    public DialogueSystem dialogueSystem;

    void Start()
    {
        isTriggered = false;
        waveNb = 0;
        bossKilled = false;
        wave1Size = wave1.Count;
        wave2Size = wave2.Count;
        wave3Size = wave3.Count;
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
            if (wave1audio.gameObject.transform.childCount == 0)
                launchWave2();
        }
        else if (waveNb == 2)
        {
            if (wave2audio.gameObject.transform.childCount == 0)
            {
                launchWave3();
            }
        }
        else if (waveNb == 3)
        {
            if (wave3audio.gameObject.transform.childCount == 0)
            {
                if (!bossKilled) {
                    dialogueSystem.playNextReply();
                    bossKilled = true;
                    if (!FindObjectOfType<AudioManager>().IsPlaying("victory"))
                    {
                        FindObjectOfType<AudioManager>().Play("victory");
                    }
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isTriggered) {
            launchWave1();
            isTriggered = true;
        }
    }

    void launchWave1()
    {
        wave1audio.enabled = true;
        waveNb += 1;
        dialogueSystem.playNextReply();
        foreach (GameObject mob in wave1)
        {
            mob.SetActive(true);
        }
    }

    void launchWave2()
    {
        wave1audio.enabled = false;
        wave2audio.enabled = true;
        waveNb += 1;
        dialogueSystem.playNextReply();
        foreach (GameObject mob in wave2)
        {
            mob.SetActive(true);
        }
    }

    void launchWave3()
    {
        wave2audio.enabled = false;
        wave3audio.enabled = true;
        waveNb += 1;
        dialogueSystem.playNextReply();
        foreach (GameObject mob in wave3)
        {
            mob.SetActive(true);
        }
    }
}
