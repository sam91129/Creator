using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mech_Switch : MonoBehaviour
{
    [Header("����ID")]
    public int ID;
    public void useSwitch()
    {
        gameManager.PlayButtonClip();
        Debug.Log("����");
        gameManager.current.SwitchUse(ID);
    }
}
