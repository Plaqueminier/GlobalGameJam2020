using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Collections.Generic;

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;

    [Range(.5f, 3f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;
}
