using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_System : MonoBehaviour
{
    public float MaxScaleSize;
    

    [Header("����ɶ�")]
    public bool isTimer;
    public float duration;
    public BoxCollider _superJump;


    [Header("���q�Y��")]
    public float normalScaleSpeed;
    [Header("�ֳt�Y��")]
    public float quickScaleSpeed;
    public float superJumpHeight;
    [Header("����ID")]
    public int ID;

    [Header("�{������")]
    public bool isPositive = false;
    Vector3 originalScale;
    bool isNormal = false;
    bool isQuick = false;
    bool isNegative = false;

    void Awake()
    {
        originalScale = transform.localScale;
        if (transform.localScale.y < MaxScaleSize) isPositive = true;
        else if (transform.localScale.y > MaxScaleSize) isNegative = true;
    }
    void Start()
    {
        _superJump.enabled = false;
        gameManager.current.onSwitchUse += SwitchScale;
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
            if(_superJump.enabled == false) _superJump.enabled = true;
            transform.localScale += new Vector3(0, quickScaleSpeed * Time.deltaTime, 0);
            if (transform.localScale.y >= MaxScaleSize)
            {
                isQuick = false;
                Revert();
                _superJump.enabled=false;
            }
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
    }
}
