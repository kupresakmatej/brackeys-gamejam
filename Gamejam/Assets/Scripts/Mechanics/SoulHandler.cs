using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            SoulsBar.lightBar.fillAmount += 10f;
            SoulsBar.light_left += 10f;

            SoulsBar.vignette.intensity.value = 0.35f;

            Destroy(transform.parent.gameObject);
        }
    }
}
