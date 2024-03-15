using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Mech_LaserAudio : MonoBehaviour
{
    public AudioSource LaserAudio;
    void Update()
    {
        if (!LaserAudio.isPlaying) RuntimeManager.PlayOneShot("event:/Mech/Event_laser");
    }
}
