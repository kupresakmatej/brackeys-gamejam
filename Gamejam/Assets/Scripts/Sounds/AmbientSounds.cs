using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientSounds : MonoBehaviour
{
    [SerializeField]
    private AudioSource clip;

    private float startVolume;

    private void Awake()
    {
        startVolume = clip.volume;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            clip.volume = startVolume;
            clip.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(FadeAudio());
        }
    }

    IEnumerator FadeAudio()
    {
        float currentTime = 0;

        float start = clip.volume;
        while (currentTime < 0.3f)
        {
            currentTime += Time.deltaTime;
            clip.volume = Mathf.Lerp(start, 0, currentTime / 0.3f);
            yield return null;
        }
        yield break;
    }
}
