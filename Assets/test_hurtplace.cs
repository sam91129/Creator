using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class test_hurtplace : MonoBehaviour
{
    
    
    public float intensity = 0;
    PostProcessVolume hurtColor;
    Vignette vignette;
    // Start is called before the first frame update
    void Start()
    {
        

        hurtColor = GetComponent<PostProcessVolume>();

        hurtColor.profile.TryGetSettings<Vignette>(out vignette);
        if (!vignette)
        {
            print("¿ù»~");

        }
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

    
    
    private IEnumerator TakeDamage()
    {
        intensity = 0.6f;

        vignette.enabled.Override(true);
        vignette.intensity.Override(0.6f);

        yield return new WaitForSeconds(0.6f);

        while (intensity > 0)
        {
            intensity -= 0.01f;

            if (intensity < 0) intensity = 0;
            vignette.intensity.Override(intensity);

            yield return new WaitForSeconds(0.1f);
        }
        vignette.enabled.Override(false);
        yield break;
    }
}
