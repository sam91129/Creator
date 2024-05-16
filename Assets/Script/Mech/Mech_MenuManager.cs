using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        _Setting.SetActive(true);
    }
    public void SaveSetting()
    {
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
