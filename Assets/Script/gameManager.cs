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
    public GameObject _sceneToLoad;
    public GameObject _pause;
    public GameObject _setting;
    public Slider progressBar;
    //---------------------------------------------聲音---------------------------------------------------------
    
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
        _sceneToLoad.SetActive(false);
        progressBar.value = 0;
        //------------------聲音------------------
        
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
        _sceneToLoad.SetActive(true);
        yield return StartCoroutine(TransitionScene());
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(Next);
        if(asyncLoad.isDone)
        {
            _sceneToLoad.SetActive(false);
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
    public void CancelPause()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerManager>().onPause();
    }
    public void Setting()
    {
        _setting.SetActive(true);
        _pause.SetActive(false);
    }
    public void SaveSetting()
    {
        _pause.SetActive(true);
        _setting.SetActive(false);
    }
    public void Menu()
    {
        //SceneManager.LoadScene("StartUI");
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
