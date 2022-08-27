using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulsPickup : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    [SerializeField]
    private float smoothTime = 0.3f;

    private Vector3 velocity = Vector3.zero;

    private bool isInTrigger;

    [SerializeField]
    private AudioSource soulSound;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            isInTrigger = true;

            soulSound.volume = 1f;
            soulSound.Play();

            StartCoroutine(MoveToPosition());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            isInTrigger = false;

            StartCoroutine(FadeAudio());

            StopCoroutine(MoveToPosition());
        }
    }

    IEnumerator FadeAudio()
    {
        float currentTime = 0;

        float start = soulSound.volume;
        while (currentTime < 0.3f)
        {
            currentTime += Time.deltaTime;
            soulSound.volume = Mathf.Lerp(start, 0, currentTime / 0.3f);
            yield return null;
        }
        yield break;
    }

    IEnumerator MoveToPosition()
    {
        float timeSinceStart = 0f;

        while(isInTrigger)
        {
            timeSinceStart += Time.deltaTime;

            transform.position = Vector3.SmoothDamp(transform.position, player.position, ref velocity, smoothTime);

            if (transform.position == player.position)
            {
                yield break;
            }
            yield return null;
        }
    }
}
