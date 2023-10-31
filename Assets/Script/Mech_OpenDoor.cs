using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Mech_OpenDoor : MonoBehaviour
{
    Animator _doorAnimator;
    [Header("機關ID")]
    public int ID;
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
            Debug.Log("開門");
            if(_doorAnimator.GetBool("SwitchON") == false) _doorAnimator.SetBool("SwitchON", true);
            else _doorAnimator.SetBool("SwitchON", false);
        }
    }
}
