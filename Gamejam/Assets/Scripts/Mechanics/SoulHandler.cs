using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoulHandler : MonoBehaviour
{
    [SerializeField]
    private Text soulsText;

    [SerializeField]
    private AudioSource soulSound;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            SoulsBar.lightBar.fillAmount += 10f;
            SoulsBar.light_left += 10f;

            SoulsBar.vignette.intensity.value = 0.35f;

            Manager.soulsCounter++;
            DisplaySouls();

            soulSound.Stop();

            Destroy(transform.parent.gameObject);
        }
    }

    private void DisplaySouls()
    {
        soulsText.text = "Souls: " + Manager.soulsCounter;
    }
}
