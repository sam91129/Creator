using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Mech_OpenDoor : MonoBehaviour
{
    Animator _doorAnimator;
    BoxCollider _autoSensing;
    public static AudioSource DoorAudio;
    [Header("自動門")]
    public bool AutomaticDoor;
    [Header("機關ID")]
    public int ID;
    void Awake()
    {
        DoorAudio = GetComponent<AudioSource>();
        _doorAnimator= GetComponent<Animator>();
        _autoSensing= this.GetComponent<BoxCollider>();
    }
    void Start()
    {
        if (AutomaticDoor)_autoSensing.enabled=true;
        else _autoSensing.enabled = false;
        gameManager.current.onSwitchUse += SwitchDoor;
    }
    public void SwitchDoor(int ID)
    {
        if (ID == this.ID)
        {
            DoorAudio.PlayOneShot(gameManager.OpenDoor);
            if(_doorAnimator.GetBool("SwitchON") == false) _doorAnimator.SetBool("SwitchON", true);
            else _doorAnimator.SetBool("SwitchON", false);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            DoorAudio.PlayOneShot(gameManager.OpenDoor);
            _doorAnimator.SetBool("SwitchON", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            _doorAnimator.SetBool("SwitchON", false);
        }
    }
}
