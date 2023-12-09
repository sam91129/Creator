using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    //---------------------------------------------場景---------------------------------------------------------
    public static string scene;
    [Header("場景_下個場景")]
    public int NextScene;
    //---------------------------------------------聲音---------------------------------------------------------
    public static AudioSource SFXaudio;
    public static AudioClip Button;
    public static AudioClip OpenDoor;
    //---------------------------------------------事件---------------------------------------------------------
    public static Event_Manager current;
    //__________________________________________________________________________________________________________
    void Awake()
    {
        //------------------場景------------------

        //------------------聲音------------------

        //------------------事件------------------
        current = this;
    }
    void Start()
    {
        //------------------場景------------------
        scene = SceneManager.GetActiveScene().name;
        //------------------聲音------------------
        SFXaudio = GetComponent<AudioSource>();
        Button = Resources.Load<AudioClip>("button");
        OpenDoor = Resources.Load<AudioClip>("門1");
        //------------------事件------------------
    }
    //---------------------------------------------場景---------------------------------------------------------
    public void ChangerScenes()
    {
        SceneManager.LoadSceneAsync(NextScene);
    }
    public void ReSpawn()
    {
        SceneManager.LoadSceneAsync(scene);
    }
    public void CloseCheck()
    {
        SceneManager.LoadScene("UI_CloseCheck", LoadSceneMode.Additive);
    }
    public void CloseCheck_No()
    {
        SceneManager.UnloadSceneAsync("UI_CloseCheck");
    }
    //---------------------------------------------聲音---------------------------------------------------------
    public static void PlayOpenDoorClip()
    {
        SFXaudio.PlayOneShot(OpenDoor);
    }
    public static void PlayButtonClip()
    {
        SFXaudio.PlayOneShot(Button);
    }

    //---------------------------------------------事件---------------------------------------------------------
    public event UnityAction<int> onSwitchUse;
    public void SwitchUse(int ID)
    {
        if (onSwitchUse != null) onSwitchUse(ID);
    }
}
