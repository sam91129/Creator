using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Mech_HurtZone : MonoBehaviour
{
    [Header("¾÷Ãö¶Ë®`")]
    public int demage;
    Player_Manager health;
    void Awake()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Manager>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (health != null)
            {
                health.Damageplayer(demage);
            }
        }
    }
}
