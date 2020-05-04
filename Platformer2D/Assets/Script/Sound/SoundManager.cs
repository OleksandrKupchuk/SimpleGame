using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class SoundManager : MonoBehaviour
{
    public Sound[] sounds;

    public static SoundManager soundManagerInstance;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if(soundManagerInstance == null)
        {
            soundManagerInstance = this;
        }

        else
        {
            Destroy(gameObject);
        }

        foreach(Sound sound in sounds)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.clip;

            sound.audioSource.volume = sound.volumeAudio;
            sound.audioSource.pitch = sound.pitchAudio;

            sound.audioSource.loop = sound.loopSound;
            sound.audioSource.playOnAwake = sound.playOnAwakeSound;
        }
    }

    public void PlaySound(string nameSound)
    {
        Sound sound =  Array.Find(sounds, soundClip => soundClip.nameAudio == nameSound);
        if(sound == null)
        {
            Debug.LogWarning("Sound: " + nameSound + " not found");
        }

        sound.audioSource.Play();
    }

    public void StopPlaySound(string nameSound)
    {
        Sound sound = Array.Find(sounds, soundClip => soundClip.nameAudio == nameSound);
        if (sound == null)
        {
            Debug.LogWarning("Sound: " + nameSound + " not found");
        }

        sound.audioSource.Stop();
    }
}
