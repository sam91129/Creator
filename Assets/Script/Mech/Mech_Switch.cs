using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mech_Switch : MonoBehaviour
{
    [Header("機關ID")]
    public int ID;
    public void useSwitch()
    {
        Event_SoundManager.PlayButtonClip();
        Debug.Log("音效");
        Event_Manager.current.SwitchUse(ID);
    }
}
