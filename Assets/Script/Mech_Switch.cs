using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mech_Switch : MonoBehaviour
{
    public int ID;
    public void useSwitch()
    {
        Event_Manager.current.SwitchUse(ID);
    }
}
