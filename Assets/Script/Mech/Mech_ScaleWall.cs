using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

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

    private FMOD.Studio.EventInstance instance;
    public FMODUnity.EventReference Event;
    void Awake()
    {
        originalScale = transform.localScale;
        if (transform.localScale.y < MaxScaleSize) isPositive = true;
        else if (transform.localScale.y > MaxScaleSize) isNegative = true;
        instance = FMODUnity.RuntimeManager.CreateInstance(Event);
        
    }
    void Start()
    {
        gameManager.current.onSwitchUse += SwitchScale;
        gameManager.current.whenRespawn += ReSet;
    }
    void Update()
    {
        if (isScale && isPositive)
        {
            transform.localScale += new Vector3(0, ScaleSpeed * Time.deltaTime, 0);
            if (transform.localScale.y >= MaxScaleSize)
            {
                StopScale();
            }


        }
        else if (isScale && isNegative)
        {
            transform.localScale -= new Vector3(0, ScaleSpeed * Time.deltaTime, 0);
            if (transform.localScale.y <= MaxScaleSize) isScale = false;
        }
    }
    public void SwitchScale(int id)
    {
        if (id == this.ID)
        {
            isScale = true;
            //Debug.Log("身長");
            instance.start();
            
        }
            if (isTimer) Invoke("Revert", duration);
    }
    public void WallChangeScale()
    {
        isScale = true;
        instance.start();
    }
    public void ReSet()
    {
        this.transform.localScale = originalScale;
        isScale = false;
    }
    void StopScale()
    {
        isScale = false;
        instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        RuntimeManager.PlayOneShot("event:/Mech/electronic bridge to the end");
    }
}
