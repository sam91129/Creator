using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    public int NextScene;
    string scene;
    void Start()
    {
        scene = SceneManager.GetActiveScene().name;
    }
    public void ChangerScenes()
    {
        SceneManager.LoadSceneAsync(NextScene);
    }
    public void ReSpawn()
    {
        SceneManager.LoadSceneAsync(scene);
    }
}

