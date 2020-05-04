﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string nameAudio;
    public AudioClip clip;

    [Range(0f, 1f)] public float volumeAudio;
    [Range(0.1f, 3f)] public float pitchAudio;

    public bool loopSound;
    public bool playOnAwakeSound;

    [HideInInspector] public AudioSource audioSource;
}
