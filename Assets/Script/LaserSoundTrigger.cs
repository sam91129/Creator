using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasersoundtrigger : MonoBehaviour
{
    public static AudioSource LaserAudio;
    // Start is called before the first frame update
    void Start()
    {
        LaserAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
            LaserAudio.Play();

            
           
        }
    }
}
