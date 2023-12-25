using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Mech_HurtZone : MonoBehaviour
{
    public static AudioSource CauteryAudio;
    [Header("�����ˮ`")]
    public int demage;
    PlayerManager health;
    void Awake()
    {
        CauteryAudio = GetComponent<AudioSource>();
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
    }
    void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            CauteryAudio.PlayOneShot(gameManager._CauteryAudio);
            if (health != null)
            {
                
                health.Damageplayer(demage);
            }
        }
    }
}
