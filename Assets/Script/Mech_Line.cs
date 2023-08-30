using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mech_Line : MonoBehaviour
{
    public int ID;
    void Start()
    {
        Event_Manager.current.onSwitchUse += ChangeMatel;
    }
    void ChangeMatel(int id)
    {
        if (id == this.ID) { print("A"); }
    }

}
