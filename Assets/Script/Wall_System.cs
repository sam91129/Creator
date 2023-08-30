using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_System : MonoBehaviour
{
    public int ID;

    [Header("持續時間")]
    public bool isTimer;
    public float duration;

    public float MaxScaleSize;
    Vector3 originalScale;

    [Header("普通縮放")]
    public float normalScaleSpeed;
    [Header("快速縮放")]
    public float quickScaleSpeed;

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
    void Start()
    {
        Event_Manager.current.onSwitchUse += SwitchScale;
    }
    void Update()
    {
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
        Debug.Log("NormalScale");
    }
    public void QuickChangeScale()
    {
        isQuick = true;
        Debug.Log("QuickScale");
    }
    public void SwitchScale(int id)
    {
        if (id == this.ID) isNormal = true;
        if (isTimer) Invoke("Revert", duration);
    }
    public void Revert()
    {
        this.transform.localScale = originalScale;
        isNormal = false;
        isQuick = false;
        Debug.Log(this.gameObject.name+"/Revert");
    }
}
