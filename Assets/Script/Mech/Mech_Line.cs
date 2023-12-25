using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mech_Line : MonoBehaviour
{
    Material originaMaterial;
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
        gameManager.current.onSwitchUse += ChangeMatel;
        gameManager.current.whenRespawn += ReSet;
        originaMaterial = myselfRenderer.sharedMaterial;
    }
    void ChangeMatel(int id)
    {
        if (id == this.ID)
        {
            if (myselfRenderer.sharedMaterial == A) myselfRenderer.sharedMaterial = B;
            else myselfRenderer.sharedMaterial = A;
        }
    }
    void ReSet()
    {
        myselfRenderer.sharedMaterial = originaMaterial;
    }
}
