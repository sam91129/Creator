using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using TMPro;
using FMODUnity;
using FMOD.Studio;

public class gameManager : MonoBehaviour
{
    static gameManager instance;
    //---------------------------------------------����---------------------------------------------------------
    public static string scene;
    [Header("����_�U�ӳ���")]
    public int Next;
    //---------------------------------------------����---------------------------------------------------------
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
    bool Timing;
    float T;
    //---------------------------------------------�n��---------------------------------------------------------

    //---------------------------------------------�ƥ�---------------------------------------------------------
    public static gameManager current;
    Bus _masterBus;
    public Slider _music;
    public Slider _sensitivity;
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
        StartCoroutine(FakeLoadScene());
        _pass.SetActive(false);
        _pause.SetActive(false);
        _setting.SetActive(false);
        _sceneToLoad.SetActive(false);
        progressBar.value = 0;
        //------------------�n��------------------
        _masterBus = RuntimeManager.GetBus("bus:/");
        //------------------�ƥ�------------------

    }
    void FixedUpdate()
    {
        if (Timing)
        {
            T += Time.deltaTime;
            _timer.text = FormatTime(T);
        }
    }
    //---------------------------------------------����---------------------------------------------------------
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
    //---------------------����----------------------------
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
        _setting.SetActive(true);
        _masterBus.getVolume(out float nowVolume);
        _music.value = nowVolume;
        _sensitivity.value = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().MouseSensitivity;
        _pause.SetActive(false);
    }
    public void SaveSetting()
    {
        SetMasterVolume();
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().MouseSensitivity = _sensitivity.value;
        _pause.SetActive(true);
        _setting.SetActive(false);
    }
    public void Menu()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void Pass()
    {
        Time.timeScale = 0;
        Timing = false;
        _thisTiming.text = FormatTime(T);
        float savedTiming = ReadTiming(scene);
        if (T <= savedTiming)
        {
            SaveTime(scene, _timer.text, T);
            _bestTiming.text = FormatTime(T);
        }
        else
        {
            _bestTiming.text = ReadTimer(scene);
        }
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().pass();
        _playerPanel.SetActive(false);
        _pass.SetActive(true);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    //---------------------------------------------�n��---------------------------------------------------------
    public void SetMasterVolume()
    {
        _masterBus.setVolume(_music.value);
    }
    //---------------------------------------------�ƥ�---------------------------------------------------------
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
    void SaveTime(string fileName, string TimingResults, float Timing)
    {
        // ���|�]�m�]�۹��Application.persistentDataPath�^
        string filePath = Path.Combine(Application.persistentDataPath, fileName);

        // �g�J�ƭȨ���
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine(TimingResults);
            writer.WriteLine(Timing);
        }
        Debug.Log("Values saved to file: " + filePath);
    }
    void LoadTiming(string fileName)
    {
        // ���|�]�m�]�۹��Application.persistentDataPath�^
        string filePath = Path.Combine(Application.persistentDataPath, fileName);

        // �p�G���s�b�A�hŪ���ƭ�
        if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                // Ū���øѪR�ƭ�
                string TimingResults;
                while ((TimingResults = reader.ReadLine()) != null)
                {
                    Debug.Log("Read string: " + TimingResults);
                }
                float Timing = float.Parse(reader.ReadLine());
                Debug.Log("Read float value: " + Timing);
            }
        }
        else
        {
            Debug.Log("File not found at: " + filePath);
        }
    }
    float ReadTiming(string fileName)
    {
        // ���|�]�m�]�۹��Application.persistentDataPath�^
        string filePath = Path.Combine(Application.persistentDataPath, fileName);

        // �p�G���s�b�A�hŪ���ƭȳ���
        if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line = reader.ReadLine();
                float value = float.Parse(line);
                Debug.Log("Read value: " + value);
                return value;
            }
        }
        else
        {
            Debug.Log("File not found at: " + filePath);
            return 0;
        }
    }
    string ReadTimer(string fileName)
    {
        string filePath = Path.Combine(Application.persistentDataPath, fileName);
        if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string loadedString = reader.ReadLine();
                return loadedString;
            }
        }
        else
        {
            return null;
        }
    }
}
