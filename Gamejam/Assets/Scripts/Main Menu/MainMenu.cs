using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Image black;
    [SerializeField]
    private Animator anim;

    public void StartGame()
    {
        SceneManager.LoadScene("Intro2");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator Fade()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
    }
}
