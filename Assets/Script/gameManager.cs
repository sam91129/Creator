using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    static gameManager instance;
    //---------------------------------------------����---------------------------------------------------------
    public static string scene;
    [Header("����_�U�ӳ���")]
    public int NextScene;
    //---------------------------------------------����---------------------------------------------------------
    public GameObject sceneToLoad;
    public Slider progressBar;
    //---------------------------------------------�n��---------------------------------------------------------
    public static AudioSource SFXaudio;
    public static AudioClip Button;
    public static AudioClip OpenDoor;
    public static AudioClip walk;
    public static AudioClip hurt;
    public static AudioClip cautery;
    //---------------------------------------------�ƥ�---------------------------------------------------------
    public static gameManager current;
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
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (this != instance) Destroy(gameObject);
        //------------------����------------------
        scene = SceneManager.GetActiveScene().name;
        //------------------����------------------
        sceneToLoad.SetActive(false);
        progressBar.value = 0;
        //------------------�n��------------------
        SFXaudio = GetComponent<AudioSource>();
        Button = Resources.Load<AudioClip>("button");
        OpenDoor = Resources.Load<AudioClip>("��1");
        walk = Resources.Load<AudioClip>("Event_walk");
        hurt = Resources.Load<AudioClip>("Evemt_hurt");
        cautery = Resources.Load<AudioClip>("Event_cautery");
        
        //------------------�ƥ�------------------

    }

    //---------------------------------------------����---------------------------------------------------------
    public void ChangerScenes()
    {
        StartCoroutine(LoadScene());
    }
    public void ReSpawn()
    {
        SceneManager.LoadSceneAsync(scene);
    }
    IEnumerator LoadScene()
    {
        Time.timeScale = 0;
        sceneToLoad.SetActive(true);
        yield return StartCoroutine(TransitionScene());
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(NextScene);
        if(asyncLoad.isDone)
        {
            sceneToLoad.SetActive(false);
            progressBar.value = 0;
        }
        Time.timeScale = 1;
    }
    IEnumerator TransitionScene()
    {
        for(float x =0; x<=0.7f; x=progressBar.value)
        {
            progressBar.value += 0.1f;
            yield return new WaitForSecondsRealtime(0.1f);
        }
        yield return new WaitForSecondsRealtime(1f);
        progressBar.value = 1;
        yield return new WaitForSecondsRealtime(2f);
        print("1000");
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
    public static void CauteryClip()
    {
        SFXaudio.PlayOneShot(cautery);
    }
    /*public static void walkClip()
    {
        if (!SFXaudio.isPlaying)
        {
            SFXaudio.clip = walk;
            SFXaudio.Play();
        }
        else
        {
            SFXaudio.Stop();
        }
    }*/
    //---------------------------------------------�ƥ�---------------------------------------------------------
    public event UnityAction<int> onSwitchUse;
    public void SwitchUse(int ID)
    {
        if (onSwitchUse != null) onSwitchUse(ID);
    }
    private void Update()
    {
        Debug.Log(cautery);
    }
}
