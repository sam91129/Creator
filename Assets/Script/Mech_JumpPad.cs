using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mech_JumpPad : MonoBehaviour
{
    public float MaxScaleSize;

    [Header("跳躍碰撞體")]
    public BoxCollider _superJump;

    [Header("縮放速度")]
    public float ScaleSpeed;

    [Header("程式控制")]
    Vector3 originalScale;
    bool isJump = false;
    void Awake()
    {
        originalScale = transform.localScale;
    }
    void Start()
    {
        _superJump.enabled = false;
    }
    void Update()
    {
        if (isJump)
        {
            if (_superJump.enabled == false) _superJump.enabled = true;
            transform.localScale += new Vector3(0, ScaleSpeed * Time.deltaTime, 0);
            if (transform.localScale.y >= MaxScaleSize)
            {
                isJump = false;
                Revert();
                _superJump.enabled = false;
            }
        }
    }
    public void WallChargeJump()
    {
        isJump = true;
    }
    public void Revert()
    {
        this.transform.localScale = originalScale;
        isJump = false;
    }
}
