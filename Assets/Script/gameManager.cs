using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using TMPro;

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
    bool Timing;
    float T;
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
        /*if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (this != instance) Destroy(gameObject);*/
        //------------------場景------------------
        scene = SceneManager.GetActiveScene().name;
        //------------------介面------------------
        StartCoroutine(FakeLoadScene());
        _pass.SetActive(false);
        _sceneToLoad.SetActive(false);
        progressBar.value = 0;
        //------------------聲音------------------
        
        //------------------事件------------------

    }
    void FixedUpdate()
    {
        if (Timing)
        {
            T += Time.deltaTime;
            _timer.text = FormatTime(T);
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
    public void MineMenu()
    {
        SceneManager.LoadSceneAsync(0);
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
        Time.timeScale = 1;
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
        yield return new WaitForSecondsRealtime(2f);
        _playerPanel.SetActive(true);
        _fakeLoadPanel.SetActive(false);
        Timing = true;
    }
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
    public void Pass()
    {
        Time.timeScale = 0;
        Timing = false;
        float savedTiming = LoadValue(scene);
        if(T <= savedTiming) SaveValues(scene, _timer.text, T);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().pass();
        _playerPanel.SetActive(false);
        _pass.SetActive(true);
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
    string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);
        int milliseconds = Mathf.FloorToInt((timeInSeconds * 1000) % 1000 /10);
        return minutes.ToString("D2") + ":" + seconds.ToString("D2") + ":" + milliseconds.ToString("D2");
    }
    void SaveValues(string fileName, string TimingResults, float Timing)
    {
        // 路徑設置（相對於Application.persistentDataPath）
        string filePath = Path.Combine(Application.persistentDataPath, fileName);

        // 寫入數值到文件
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine(TimingResults);
            writer.WriteLine(Timing);
        }
        Debug.Log("Values saved to file: " + filePath);
    }
    void LoadValues(string fileName)
    {
        // 路徑設置（相對於Application.persistentDataPath）
        string filePath = Path.Combine(Application.persistentDataPath, fileName);

        // 如果文件存在，則讀取數值
        if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                // 讀取並解析數值
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
    int LoadValue(string fileName)
    {
        // 路徑設置（相對於Application.persistentDataPath）
        string filePath = Path.Combine(Application.persistentDataPath, fileName);

        // 如果文件存在，則讀取數值部分
        if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line = reader.ReadLine();
                int value = int.Parse(line);
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
}
