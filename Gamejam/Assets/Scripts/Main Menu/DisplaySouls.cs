using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplaySouls : MonoBehaviour
{
    [SerializeField]
    private Text soulsText;
    [SerializeField]
    private GameObject soulsTex;

    [SerializeField]
    private GameObject credits;

    private void Awake()
    {
        soulsTex.SetActive(false);
    }

    void Update()
    {
        if(credits.activeSelf)
        {
            soulsTex.SetActive(true);

            soulsText.text = soulsText.text + Manager.soulsCounter.ToString() + "/12";
        }
    }
}
