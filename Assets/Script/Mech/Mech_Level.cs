using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Mech_Level : MonoBehaviour
{
    string sceneName;
    public string _bestTime;
    public void L1()
    {
        sceneName = GetSceneNameByIndex(1);
        string fileName = sceneName;
        _bestTime = ReadTimer(fileName);
        Debug.Log("Loaded string: " + _bestTime);
        GameObject.Find("MenuObject").GetComponent<Mech_MenuManager>().ContinueScnen = 1;
    }
    public void L2()
    {
        sceneName = GetSceneNameByIndex(2);
        string fileName = sceneName;
        _bestTime = ReadTimer(fileName);
        Debug.Log("Loaded string: " + _bestTime);
        GameObject.Find("MenuObject").GetComponent<Mech_MenuManager>().ContinueScnen = 2;
    }
    string GetSceneNameByIndex(int index)
    {
        
        Scene scene = SceneManager.GetSceneByBuildIndex(index);     // ������w�����s���������W��
        if (scene.IsValid())                                        // �p�G�������ġA��^�����W�١F�_�h��^�Ŧr�Ŧ�
        {
            return scene.name;
        }
        else
        {
            return "";
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
            return "";
        }
    }
}
