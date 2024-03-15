using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Mech_Switch : MonoBehaviour
{
    public AudioSource ButtonAudio;
    [Header("¾÷ÃöID")]
    public int ID;
    public void useSwitch()
    {
        RuntimeManager.PlayOneShot("event:/Mech/Event_button");
        gameManager.current.SwitchUse(ID);
    }
}
