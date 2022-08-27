using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject imageObject;

    [SerializeField]
    private GameObject pauseObj;

    [SerializeField]
    private GameObject lightLeft;

    public static int soulsCounter;

    private bool isPaused;

    [SerializeField]
    private GameObject menu;
    [SerializeField]
    private GameObject menuText;
    [SerializeField]
    private GameObject menuButton;
    [SerializeField]
    private GameObject imageObj;

    void Awake()
    {
        Time.timeScale = 1;

        imageObject.SetActive(true);

        pauseObj.SetActive(false);

        lightLeft.SetActive(true);

        menu.SetActive(false);
        menuText.SetActive(false);
        menuButton.SetActive(false);

        imageObj.SetActive(true);
    }

    void Update()
    {
        if(!isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;

            lightLeft.SetActive(false);
            pauseObj.SetActive(true);

            menu.SetActive(true);
            menuText.SetActive(true);
            menuButton.SetActive(true);

            imageObj.SetActive(false);

            isPaused = true;
        }
        else if (isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1;

            pauseObj.SetActive(false);

            lightLeft.SetActive(true);

            menu.SetActive(false);
            menuText.SetActive(false);
            menuButton.SetActive(false);

            imageObj.SetActive(true);

            isPaused = false;
        }
    }

    void Start()
    {
        StartCoroutine(Instructions());
    }

    IEnumerator Instructions()
    {
        yield return new WaitForSeconds(5f);

        imageObject.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
