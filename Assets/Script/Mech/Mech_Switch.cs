using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mech_Switch : MonoBehaviour
{
    [Header("����ID")]
    public int ID;
    public void useSwitch()
    {
        GameManager.PlayButtonClip();
        Debug.Log("����");
        GameManager.current.SwitchUse(ID);
    }
}
