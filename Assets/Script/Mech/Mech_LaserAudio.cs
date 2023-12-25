using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mech_LaserAudio : MonoBehaviour
{
    public AudioSource LaserAudio;
    void Update()
    {
        if (!LaserAudio.isPlaying) LaserAudio.PlayOneShot(gameManager._LaserAudio);
    }
}
