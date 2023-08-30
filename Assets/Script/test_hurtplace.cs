using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class test_hurtplace : MonoBehaviour
{
    public float maxIntensity;
    public float WaitTime;
    public float DelayTime;
    float intensity;
    PostProcessVolume hurtColor;
    Vignette vignette;
    void Awake()
    {
        hurtColor = GameObject.FindWithTag("HurtEffect").GetComponent<PostProcessVolume>();
        hurtColor.profile.TryGetSettings<Vignette>(out vignette);
    }
    public void FlashScreen()
    {
        StartCoroutine(TakeDamage());
    }
    // Update is called once per frame
    IEnumerator TakeDamage()
    {
        intensity = maxIntensity;

        vignette.enabled.Override(true);
        vignette.intensity.Override(intensity);

        yield return new WaitForSeconds(WaitTime);

        while (intensity > 0)
        {
            intensity -= 0.01f;
            vignette.intensity.Override(intensity);
            yield return new WaitForSeconds(DelayTime);
        }
        vignette.enabled.Override(false);
        yield break;
    }
}
