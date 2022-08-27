using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroCar : MonoBehaviour
{
    [SerializeField]
    private GameObject black;

    [SerializeField]
    private AudioSource clip;
    [SerializeField]
    private AudioSource engineClip;

    void Start()
    {
        black.SetActive(false);

        engineClip.Play();

        StartCoroutine(PlayIntro());
    }


    IEnumerator PlayIntro()
    {
        yield return new WaitForSeconds(8f);

        engineClip.Stop();

        black.SetActive(true);

        clip.Play();

        StartCoroutine(FadeAudio());
    }

    IEnumerator FadeAudio()
    {
        float currentTime = 0;

        float start = clip.volume;
        while (currentTime < 7f)
        {
            currentTime += Time.deltaTime;
            clip.volume = Mathf.Lerp(start, 0, currentTime / 7f);

            StartCoroutine(SwitchScene());
            yield return null;
        }
        yield break;
    }

    IEnumerator SwitchScene()
    {
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene("Level 1");
    }
}
