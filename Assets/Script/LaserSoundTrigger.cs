using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasersoundtrigger : MonoBehaviour
{
    public static AudioSource laserAudio;
    // Start is called before the first frame update
    void Start()
    {
        laserAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!laserAudio.isPlaying)
            {laserAudio.Play();
            Debug.Log("123");
            }
            
           
        }
    }*/
}
