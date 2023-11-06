using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class test_hurtplace : MonoBehaviour
{
    [Header("�h�[����h")]
    public float WaitTime;
    [Header("���h�t�v")]
    public float DelayTime;

    float maxWeight = 1;
    Volume hurtColor;
    void Awake()
    {
        hurtColor = GameObject.FindWithTag("HurtEffect").GetComponent<Volume>();
    }
    void Start()
    {
        hurtColor.weight = 0;
    }
    public void FlashScreen()
    {
        StartCoroutine(TakeDamage());
    }
    IEnumerator TakeDamage()
    {
        hurtColor.weight = maxWeight;
        yield return new WaitForSeconds(WaitTime);
        while (hurtColor.weight > 0)
        {
            hurtColor.weight -= 0.01f;
            yield return new WaitForSeconds(DelayTime);
        }
        yield break;
    }
}
