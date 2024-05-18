using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Mech_Level : MonoBehaviour
{
    public TextMeshProUGUI _level;
    public TextMeshProUGUI _timer;

    string sceneName;
    public string _bestTime;
    public void L1()
    {
        sceneName = GetSceneNameByIndex(1);
        _level.text = "L1";
        _timer.text = PlayerPrefs.GetString(sceneName + "Timer", "00:00:00");
        GameObject.Find("MenuObject").GetComponent<Mech_MenuManager>().ContinueScnen = 1;
    }
    public void L2()
    {
        sceneName = GetSceneNameByIndex(2);
        _level.text = "L2";
        _timer.text = PlayerPrefs.GetString(sceneName + "Timer", "00:00:00");
        GameObject.Find("MenuObject").GetComponent<Mech_MenuManager>().ContinueScnen = 2;
    }
    string GetSceneNameByIndex(int index)
    {
        string scenePath = SceneUtility.GetScenePathByBuildIndex(index);     
        string sceneName = System.IO.Path.GetFileNameWithoutExtension(scenePath);
        return sceneName;
    }
}
