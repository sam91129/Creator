using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mech_Switch : MonoBehaviour
{
    public AudioSource ButtonAudio;
    [Header("¾÷ÃöID")]
    public int ID;
    public void useSwitch()
    {
        ButtonAudio.PlayOneShot(gameManager._ButtonAudio);
        gameManager.current.SwitchUse(ID);
    }
}
