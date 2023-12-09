using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mech_Switch : MonoBehaviour
{
    [Header("機關ID")]
    public int ID;
    public void useSwitch()
    {
        GameManager.PlayButtonClip();
        Debug.Log("音效");
        GameManager.current.SwitchUse(ID);
    }
}
