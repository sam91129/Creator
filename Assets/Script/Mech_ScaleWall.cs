using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mech_ScaleWall : MonoBehaviour
{
    public float MaxScaleSize;

    [Header("持續時間")]
    public bool isTimer;
    public float duration;

    [Header("縮放速度")]
    public float ScaleSpeed;
    
    [Header("機關ID")]
    public int ID;

    [Header("程式控制")]
    Vector3 originalScale;
    bool isScale = false;
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
        if (isScale && isPositive)
        {
            transform.localScale += new Vector3(0, ScaleSpeed * Time.deltaTime, 0);
            if (transform.localScale.y >= MaxScaleSize) isScale = false;
        }
        else if (isScale && isNegative)
        {
            transform.localScale -= new Vector3(0, ScaleSpeed * Time.deltaTime, 0);
            if (transform.localScale.y <= MaxScaleSize) isScale = false;
        }
    }
    public void SwitchScale(int id)
    {
        if (id == this.ID) isScale = true;
        if (isTimer) Invoke("Revert", duration);
    }
    public void WallChangeScale()
    {
        isScale = true;
    }
    public void Revert()
    {
        this.transform.localScale = originalScale;
        isScale = false;
    }
}
