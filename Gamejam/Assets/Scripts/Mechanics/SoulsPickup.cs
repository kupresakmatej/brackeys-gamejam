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

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(MoveToPosition());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            StopCoroutine(MoveToPosition());
        }
    }

    IEnumerator MoveToPosition()
    {
        float timeSinceStart = 0f;

        while(true)
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
