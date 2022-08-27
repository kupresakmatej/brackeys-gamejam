using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSound : MonoBehaviour
{
    [SerializeField]
    private AudioSource ghostSound;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            ghostSound.volume = 1;

            ghostSound.Play();
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

        float start = ghostSound.volume;
        while (currentTime < 0.3f)
        {
            currentTime += Time.deltaTime;
            ghostSound.volume = Mathf.Lerp(start, 0, currentTime / 0.3f);
            yield return null;
        }
        yield break;
    }
}
