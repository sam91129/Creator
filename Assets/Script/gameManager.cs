using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //---------------------------------------------����---------------------------------------------------------
    public static string scene;
    [Header("����_�U�ӳ���")]
    public int NextScene;
    //---------------------------------------------����---------------------------------------------------------

    //---------------------------------------------�n��---------------------------------------------------------
    public static AudioSource SFXaudio;
    public static AudioClip Button;
    public static AudioClip OpenDoor;
    //---------------------------------------------�ƥ�---------------------------------------------------------
    public static GameManager current;
    //__________________________________________________________________________________________________________
    void Awake()
    {
        //------------------����------------------

        //------------------����------------------

        //------------------�n��------------------

        //------------------�ƥ�------------------
        current = this; 
    }
    void Start()
    {
        //------------------����------------------
        scene = SceneManager.GetActiveScene().name;
        //------------------����------------------

        //------------------�n��------------------
        SFXaudio = GetComponent<AudioSource>();
        Button = Resources.Load<AudioClip>("button");
        OpenDoor = Resources.Load<AudioClip>("��1");
        //------------------�ƥ�------------------

    }
    //---------------------------------------------����---------------------------------------------------------
    public void ChangerScenes()
    {
        SceneManager.LoadSceneAsync(NextScene);
    }
    public void ReSpawn()
    {
        SceneManager.LoadSceneAsync(scene);
    }
    
    //---------------------����----------------------------
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
    //---------------------------------------------�n��---------------------------------------------------------
    public static void PlayOpenDoorClip()
    {
        SFXaudio.PlayOneShot(OpenDoor);
    }
    public static void PlayButtonClip()
    {
        SFXaudio.PlayOneShot(Button);
    }
    //---------------------------------------------�ƥ�---------------------------------------------------------
    public event UnityAction<int> onSwitchUse;
    public void SwitchUse(int ID)
    {
        if (onSwitchUse != null) onSwitchUse(ID);
    }
}
