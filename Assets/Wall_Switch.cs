using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Switch : MonoBehaviour
{
   
    public GameObject Target;
    public bool isTimer;
    [Header("����ɶ�")]
    public float duration;


    public void useSwitch()
    {
        Target.GetComponent<Wall_System>().NormalChangeScale();
        if (isTimer) Invoke("TimeLimit" ,5);
    }

    void TimeLimit()
    {
        Target.GetComponent<Wall_System>().Revert();
    }
    
}
