using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mech_Switch : MonoBehaviour
{
    [Header("����ID")]
    public int ID;
    public void useSwitch()
    {
        Event_SoundManager.PlayButtonClip();
        Debug.Log("����");
        Event_Manager.current.SwitchUse(ID);
    }
}
