using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mech_MenuManager : MonoBehaviour
{
    public GameObject _Menu;
    public GameObject _Level;
    public GameObject _About;
    public GameObject _Setting;
    [Header("(¼È®É)³õ´º")]
    public string ContinueScnen;
    public void Continue()
    {
        _Menu.SetActive(false);
        SceneManager.LoadSceneAsync(ContinueScnen);
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
}
