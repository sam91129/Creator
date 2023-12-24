using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Mech_HurtZone : MonoBehaviour
{
    [Header("¾÷Ãö¶Ë®`")]
    public int demage;
    PlayerManager health;
    void Awake()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
    }
    void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            gameManager.CauteryClip();
            if (health != null)
            {
                
                health.Damageplayer(demage);
            }
        }
    }
}
