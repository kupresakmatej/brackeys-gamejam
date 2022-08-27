using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private GameObject lightObj;
    [SerializeField]
    private GameObject endObj;
    [SerializeField]
    private GameObject bar;

    [SerializeField]
    private AudioSource endMusic;

    [SerializeField]
    private GameObject mainSound;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject lightPoint;
    [SerializeField]
    private GameObject lightSpot;

    [SerializeField]
    private Animator anim;
    [SerializeField]
    private GameObject canvasEnd;

    [SerializeField]
    private GameObject directionalLight;

    void Awake()
    {
        lightObj.SetActive(false);
        bar.SetActive(true);
        mainSound.SetActive(true);
        player.SetActive(true);
        lightPoint.SetActive(true);
        lightSpot.SetActive(true);
        canvasEnd.SetActive(false);
        directionalLight.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.attachedRigidbody.isKinematic = false;

            lightObj.SetActive(true);
            bar.SetActive(false);

            mainSound.SetActive(false);

            player.SetActive(false);

            lightPoint.SetActive(false);
            lightSpot.SetActive(false);

            directionalLight.SetActive(false);

            StartCoroutine(EndScreen());
        }
    }

    IEnumerator EndScreen()
    {
        yield return new WaitForSeconds(4f);

        endMusic.Play();

        lightObj.SetActive(false);
        endObj.SetActive(true);

        canvasEnd.SetActive(true);
        anim.Play("Credits");
    }
}
