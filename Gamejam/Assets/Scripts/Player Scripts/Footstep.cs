using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footstep : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip clip;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Step()
    {
        AudioClip clipSound = clip;
        audioSource.PlayOneShot(clipSound);
    }

    private void Run()
    {
        AudioClip runClip = clip;
        audioSource.PlayOneShot(runClip);
    }
}
