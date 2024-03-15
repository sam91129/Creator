using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    static gameManager instance;
    //---------------------------------------------場景---------------------------------------------------------
    public static string scene;
    [Header("場景_下個場景")]
    public int Next;
    //---------------------------------------------介面---------------------------------------------------------
    public GameObject sceneToLoad;
    public Slider progressBar;
    //---------------------------------------------聲音---------------------------------------------------------
    public static AudioSource SFXAudio;
    public static AudioClip _ButtonAudio;
    public static AudioClip _OpenDoorAudio;
    public static AudioClip _WalkAudio;
    public static AudioClip _RunAudio;
    public static AudioClip _HurtAudio;
    public static AudioClip _CauteryAudio;
    public static AudioClip _LaserAudio;
    public static AudioClip _JumpAudio;
    //---------------------------------------------事件---------------------------------------------------------
    public static gameManager current;
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
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (this != instance) Destroy(gameObject);
        //------------------場景------------------
        scene = SceneManager.GetActiveScene().name;
        //------------------介面------------------
        sceneToLoad.SetActive(false);
        progressBar.value = 0;
        //------------------聲音------------------
        SFXAudio = GetComponent<AudioSource>();
        //_ButtonAudio = Resources.Load<AudioClip>("Event_button");
        //_OpenDoorAudio = Resources.Load<AudioClip>("Event_door");
        _WalkAudio = Resources.Load<AudioClip>("Event_walk");
        _RunAudio = Resources.Load<AudioClip>("Event_run");
        //_HurtAudio = Resources.Load<AudioClip>("Evemt_hurt");
        //_CauteryAudio = Resources.Load<AudioClip>("Event_cautery");
        //_LaserAudio = Resources.Load<AudioClip>("Event_laser");
        //_JumpAudio = Resources.Load<AudioClip>("Event_jump");

        //------------------事件------------------

    }

    //---------------------------------------------場景---------------------------------------------------------
    public void ChangerScenes()
    {
        StartCoroutine(LoadScene());
    }
    public void ReSpawn()
    {
        whenRespawn();
    }
    IEnumerator LoadScene()
    {
        Time.timeScale = 0;
        sceneToLoad.SetActive(true);
        yield return StartCoroutine(TransitionScene());
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(Next);
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
    
    //---------------------------------------------事件---------------------------------------------------------
    public event UnityAction<int> onSwitchUse;
    public event UnityAction whenRespawn;
    public void SwitchUse(int ID)
    {
        if (onSwitchUse != null) onSwitchUse(ID);
    }
}
