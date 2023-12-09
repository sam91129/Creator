using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_SoundManager : MonoBehaviour
{
    public static AudioSource SFXaudio;
    public static AudioClip Button;
    public static AudioClip OpenDoor;
    // Start is called before the first frame update
    void Start()
    {
        SFXaudio = GetComponent<AudioSource>();
        Button = Resources.Load<AudioClip>("button");
        OpenDoor = Resources.Load<AudioClip>("ªù1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlayOpenDoorClip()
    {
        SFXaudio.PlayOneShot(OpenDoor);
    }
    public static void PlayButtonClip()
    {
        SFXaudio.PlayOneShot(Button);
    }
}
