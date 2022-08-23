using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class SoulsBar : MonoBehaviour
{
    private const float MAX_LIGHT = 100f;

    public static float light_left = MAX_LIGHT;

    public static Image lightBar;

    [SerializeField]
    private Light lightIntensity;

    [SerializeField]
    private float loseLight = 0.0001f;

    private PostProcessVolume v;
    public static Vignette vignette;
    [SerializeField]
    private Camera mainCamera;

    void Start()
    {
        v = mainCamera.GetComponent<PostProcessVolume>();
        v.profile.TryGetSettings(out vignette);

        lightBar = GetComponent<Image>();

        lightBar.fillAmount = light_left / MAX_LIGHT;
    }

    // Update is called once per frame
    void Update()
    {

        if(PlayerMovement.state == PlayerMovement.MovementState.sprinting)
        {
            lightBar.fillAmount -= (loseLight + 0.05f) * Time.deltaTime;

            lightIntensity.intensity = light_left - (loseLight + 0.05f) * Time.deltaTime;
            vignette.intensity.value += (loseLight + 0.05f) / 2.5f * Time.deltaTime;
        }
        else
        {
            lightBar.fillAmount -= loseLight * Time.deltaTime;

            lightIntensity.intensity = light_left - loseLight * Time.deltaTime;
            vignette.intensity.value += loseLight / 2.5f * Time.deltaTime;
        }

        light_left = lightBar.fillAmount;
    }
}
