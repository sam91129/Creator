using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mech_Line : MonoBehaviour
{
    Material myself;
    Renderer myselfRenderer;
    [Header("纜線材質")]
    public Material A;
    public Material B;
    [Header("機關ID")]
    public int ID;
    void Start()
    {
        myselfRenderer = GetComponent<Renderer>();
        myselfRenderer.sharedMaterial = A;
        Event_Manager.current.onSwitchUse += ChangeMatel;
    }
    void ChangeMatel(int id)
    {
        if (id == this.ID)
        {
            if (myselfRenderer.sharedMaterial == A) myselfRenderer.sharedMaterial = B;
            else myselfRenderer.sharedMaterial = A;
        }
    }
}
