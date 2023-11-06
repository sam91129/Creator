using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class test_hurtplace : MonoBehaviour
{
    [Header("多久後消退")]
    public float WaitTime;
    [Header("消退速率")]
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
