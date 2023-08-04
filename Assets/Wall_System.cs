using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_System : MonoBehaviour
{
    public float MaxScaleSize;
    Vector3 originalScale;

    float normalScaleSpeed = 1f;
    float quickScaleSpeed = 15.0f;
    float x;

    bool isNormal = false;
    bool isQuick = false;
    bool isPositive = false;
    bool isNegative = false;

    void Awake()
    {
        originalScale = transform.localScale;
        if (transform.localScale.y < MaxScaleSize) isPositive = true;
        else if (transform.localScale.y > MaxScaleSize) isNegative = true;
    }
    void Update()
    {
        Debug.Log(transform.localScale);
        if (isNormal && isPositive)
        {
            transform.localScale += new Vector3(0, normalScaleSpeed * Time.deltaTime,0);
            if(transform.localScale.y >= MaxScaleSize) isNormal = false;
        }
        if (isNormal && isNegative)
        {
            transform.localScale -= new Vector3(0, normalScaleSpeed * Time.deltaTime, 0);
            if (transform.localScale.y <= MaxScaleSize) isNormal = false;
        }
        if (isQuick && isPositive)
        {
            transform.localScale += new Vector3(0, quickScaleSpeed * Time.deltaTime, 0);
            if (transform.localScale.y >= MaxScaleSize) isQuick = false;
        }
        if (isQuick && isNegative)
        {
            transform.localScale -= new Vector3(0, quickScaleSpeed * Time.deltaTime, 0);
            if (transform.localScale.y <= MaxScaleSize) isQuick = false;
        }
    }
    public void NormalChangeScale()
    {
        isNormal = true;
    }
    public void QuickChangeScale()
    {
        isQuick = true;
    }
    public void Revert()
    {
        this.transform.localScale = originalScale;
    }
}
