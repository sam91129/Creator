using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using FMODUnity;
using FMOD.Studio;
using TMPro;

public class Mech_MenuManager : MonoBehaviour
{
    public GameObject _Menu;
    public GameObject _Level;
    public GameObject _About;
    public GameObject _Setting;
    [Header("(¼È®É)³õ´º")]
    public int ContinueScnen;
    public GameObject _sceneToLoad;
    public Slider progressBar;
    Bus _masterBus;
    public Slider _musicBar;
    public Slider _sensitivityBar;
    public TextMeshProUGUI _music;
    public TextMeshProUGUI _sensitivity;
    void Awake()
    {
        _masterBus = RuntimeManager.GetBus("bus:/");
        _masterBus.setVolume(PlayerPrefs.GetFloat("MusicVolume", 1.0f));
    }
    void Start()
    {
        _Menu.SetActive(true);
        _Level.SetActive(false);
        _About.SetActive(false);
        _Setting.SetActive(false);
        _sceneToLoad.SetActive(false);
    }
    public void Continue()
    {
        StartCoroutine(LoadScene());
    }
    public void NewGame()
    {
        _Menu.SetActive(false);
        _Level.SetActive(true);
    }
    public void LevelSleted()
    {
        _Menu.SetActive(false);
        _Level.SetActive(true);
    }
    public void Setting()
    {
        _Menu.SetActive(false);
        _musicBar.value = PlayerPrefs.GetFloat("MusicVolume", 1.0f);
        MusicBarVolume();
        _sensitivityBar.value = PlayerPrefs.GetFloat("Sensitivity", 1.0f);
        SensitivityBarVolume();
        _Setting.SetActive(true);
    }
    public void MusicBarVolume()
    {
        float Volume = _musicBar.value * 100;
        _music.text = Volume.ToString("0") + "%";
    }
    public void SensitivityBarVolume()
    {
        _sensitivity.text = _sensitivityBar.value.ToString("F2");
    }
    public void SaveSetting()
    {
        _masterBus.setVolume(_musicBar.value);
        PlayerPrefs.SetFloat("Sensitivity", _sensitivityBar.value);
        PlayerPrefs.SetFloat("MusicVolume", _musicBar.value);
        PlayerPrefs.Save();
        _Setting.SetActive(false);
        _Menu.SetActive(true);
    }
    public void About()
    {
        _Menu.SetActive(false);
        _About.SetActive(true);
    }
    public void Back()
    {
        _Level.SetActive(false);
        _Setting.SetActive(false);
        _About.SetActive(false);
        _Menu.SetActive(true);
    }
    public void Exit()
    {
        Application.Quit();
    }
    IEnumerator LoadScene()
    {
        _sceneToLoad.SetActive(true);
        for (float x = 0; x <= 0.7f; x = progressBar.value)
        {
            progressBar.value += 0.1f;
            yield return new WaitForSecondsRealtime(0.1f);
        }
        progressBar.value = 1;
        SceneManager.LoadSceneAsync(ContinueScnen);
    }
}
