using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mech_Switch : MonoBehaviour
{
   
    public GameObject Target;
    [Header("持續時間")]
    public bool isTimer;
    public float duration;
    public void useSwitch()
    {
        Target.GetComponent<Wall_System>().NormalChangeScale();
        if (isTimer) Invoke("TimeLimit", 5);
    }
    void TimeLimit()
    {
        Target.GetComponent<Wall_System>().Revert();
    }
}
