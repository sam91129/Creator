using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Mech_OpenDoor : MonoBehaviour
{
    public int ID;
    Animator _doorAnimator;
    bool _openDoor;
    void Awake()
    {
        _doorAnimator= GetComponent<Animator>();
    }
    void Start()
    {
        Event_Manager.current.onSwitchUse += SwitchDoor;
    }
    public void SwitchDoor(int ID)
    {
        if (ID == this.ID)
        {
            Event_SoundManager.PlayOpenDoorClip();
            Debug.Log("�}��");
            if(_doorAnimator.GetBool("SwitchON") == false) _doorAnimator.SetBool("SwitchON", true);
            else _doorAnimator.SetBool("SwitchON", false);
        }
    }
}
