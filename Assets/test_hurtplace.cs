using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class test_hurtplace : MonoBehaviour
{
    public float maxIntensity;
    public float DelayTime;
    float intensity;
    PostProcessVolume hurtColor;
    Vignette vignette;
    void Start()
    {
        hurtColor = GetComponent<PostProcessVolume>();
        hurtColor.profile.TryGetSettings<Vignette>(out vignette);

        if (!vignette) print("¿ù»~");
        else
        {
            print("¥¿½T");
            vignette.enabled.Override(false);
        }
    }

    public void FlashScreen()
    {
        StartCoroutine(TakeDamage());
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            StartCoroutine(TakeDamage());
    }
    IEnumerator TakeDamage()
    {
        intensity = maxIntensity;

        vignette.enabled.Override(true);
        vignette.intensity.Override(intensity);

        yield return new WaitForSeconds(0.25f);

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
