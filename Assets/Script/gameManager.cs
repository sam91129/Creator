using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using FMODUnity;
using FMOD.Studio;

public class gameManager : MonoBehaviour
{
    static gameManager instance;
    //---------------------------------------------場景---------------------------------------------------------
    public static string scene;
    [Header("場景_下個場景")]
    public int Next;
    //---------------------------------------------介面---------------------------------------------------------
    public GameObject _playerPanel;
    public GameObject _sceneToLoad;
    public GameObject _fakeLoadPanel;
    public GameObject _pause;
    public GameObject _setting;
    public GameObject _pass;
    public Slider progressBar;
    public TextMeshProUGUI _timer;
    public TextMeshProUGUI _bridge;
    public TextMeshProUGUI _thisTiming;
    public TextMeshProUGUI _bestTiming;
    public bool canPause;
    bool Timing;
    float nowTimimg;
    //---------------------------------------------聲音---------------------------------------------------------

    //---------------------------------------------事件---------------------------------------------------------
    public static gameManager current;
    Bus _masterBus;
    public Slider _musicBar;
    public Slider _sensitivityBar;
    public TextMeshProUGUI _music;
    public TextMeshProUGUI _sensitivity;
    //__________________________________________________________________________________________________________
    void Awake()
    {
        //------------------場景------------------

        //------------------介面------------------
        canPause = false;
        //------------------聲音------------------
        _masterBus = RuntimeManager.GetBus("bus:/");
        _masterBus.setVolume(PlayerPrefs.GetFloat("MusicVolume", 1.0f));
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
        StartCoroutine(FakeLoadScene());
        _pass.SetActive(false);
        _pause.SetActive(false);
        _setting.SetActive(false);
        _sceneToLoad.SetActive(false);
        progressBar.value = 0;
        //------------------聲音------------------
        Debug.Log(scene + "Timer");
        //------------------事件------------------

    }
    void FixedUpdate()
    {
        if (Timing)
        {
            nowTimimg += Time.deltaTime;
            _timer.text = FormatTime(nowTimimg);
        }
    }
    //---------------------------------------------場景---------------------------------------------------------
    public void ChangerScenes()
    {
        _pass.SetActive(false);
        StartCoroutine(LoadScene());
    }
    public void Again()
    {
        Next -= 1;
        StartCoroutine(LoadScene());
    }
    public void ReSpawn()
    {
        whenRespawn();
    }
    public void ReStrt()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
    IEnumerator LoadScene()
    {
        Time.timeScale = 0;
        _sceneToLoad.SetActive(true);
        yield return StartCoroutine(TransitionScene());
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(Next);
        if (asyncLoad.isDone)
        {
            _sceneToLoad.SetActive(false);
            progressBar.value = 0;
        }
    }
    IEnumerator TransitionScene()
    {
        for(float x =0; x<=0.7f; x=progressBar.value)
        {
            progressBar.value += 0.1f;
            yield return new WaitForSecondsRealtime(0.1f);
        }
        progressBar.value = 1;
        yield return new WaitForSecondsRealtime(2f);
    }
    //---------------------介面----------------------------
    IEnumerator FakeLoadScene()
    {
        Timing = false;
        _timer.text = "00:00:00";
        _fakeLoadPanel.SetActive(true);
        Time.timeScale = 1;
        yield return new WaitForSecondsRealtime(2f);
        _playerPanel.SetActive(true);
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().HadGloves == false) _bridge.enabled = false;
        else _bridge.enabled = true;
        _fakeLoadPanel.SetActive(false);
        canPause = true;
        Timing = true;
    }
    public void CancelPause()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerManager>().onPause();
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Setting()
    {
        canPause = false;
        _pause.SetActive(false);
        _musicBar.value = PlayerPrefs.GetFloat("MusicVolume", 1.0f);
        _sensitivityBar.value = PlayerPrefs.GetFloat("Sensitivity", 1.0f);
        _setting.SetActive(true);
    }
    public void SaveSetting()
    {
        _masterBus.setVolume(_musicBar.value); 
        _musicBar.value = PlayerPrefs.GetFloat("MusicVolume", 1.0f);
        MusicBarVolume();
        _sensitivityBar.value = PlayerPrefs.GetFloat("Sensitivity", 1.0f);
        SensitivityBarVolume();
        PlayerPrefs.Save();
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().setSensitivity();
        canPause = true;
        _pause.SetActive(true);
        _setting.SetActive(false);
    }
    public void Menu()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void Pass()
    {
        Timing = false;
        canPause = false;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Confined;
        _playerPanel.SetActive(false);
        _thisTiming.text = _timer.text;
        if (nowTimimg < PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + "Timing", 0f))
        {
            _bestTiming.text = _timer.text;
            PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "Timing", nowTimimg);
            PlayerPrefs.SetString(SceneManager.GetActiveScene().name + "Timer", _timer.text);
            PlayerPrefs.Save();
        }
        else
        {
            _bestTiming.text = PlayerPrefs.GetString(SceneManager.GetActiveScene().name + "Timer", "00:00:00");
        }
        _pass.SetActive(true);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    //---------------------------------------------聲音---------------------------------------------------------
    public void MusicBarVolume()
    {
        _music.text = _musicBar.value.ToString("F2");
    }
    public void SensitivityBarVolume()
    {
        _sensitivity.text = _sensitivityBar.value.ToString("F2");
    }
    //---------------------------------------------事件---------------------------------------------------------
    public event UnityAction<int> onSwitchUse;
    public event UnityAction whenRespawn;
    public void SwitchUse(int ID)
    {
        if (onSwitchUse != null) onSwitchUse(ID);
    }
    string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);
        int milliseconds = Mathf.FloorToInt((timeInSeconds * 1000) % 1000 /10);
        return minutes.ToString("D2") + ":" + seconds.ToString("D2") + ":" + milliseconds.ToString("D2");
    }
}
