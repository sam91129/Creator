using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //---------------------------------------------場景---------------------------------------------------------
    public static string scene;
    [Header("場景_下個場景")]
    public int NextScene;
    //---------------------------------------------介面---------------------------------------------------------

    //---------------------------------------------聲音---------------------------------------------------------
    public static AudioSource SFXaudio;
    public static AudioClip Button;
    public static AudioClip OpenDoor;
    //---------------------------------------------事件---------------------------------------------------------
    public static GameManager current;
    //__________________________________________________________________________________________________________
    void Awake()
    {
        //------------------場景------------------

        //------------------介面------------------

        //------------------聲音------------------

        //------------------事件------------------
        current = this; 
    }
    void Start()
    {
        //------------------場景------------------
        scene = SceneManager.GetActiveScene().name;
        //------------------介面------------------

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
    
    //---------------------介面----------------------------
    public void PauseGame()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene("UI_Pause", LoadSceneMode.Additive);
    }
    public void UnpauseGame()
    {
        Time.timeScale = 1;
        SceneManager.UnloadSceneAsync("UI_Pause");
    }
    public void CloseCheck()
    {
        SceneManager.LoadScene("UI_CloseCheck", LoadSceneMode.Additive);
    }
    public void CancelClose()
    {
        SceneManager.UnloadSceneAsync("UI_CloseCheck");
    }
    public void ExitGame()
    {
        Application.Quit();
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
