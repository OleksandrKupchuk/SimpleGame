using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundOnBackground : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Slider slider;

    void Start()
    {
        slider.value = 0.1f;
        audioSource.Play();
    }

    private void Update()
    {
        audioSource.volume = slider.value;
    }
}
