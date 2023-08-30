using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    public Scene NextScene;
    string scene;
    void Start()
    {
        scene = SceneManager.GetActiveScene().name;
    }
    void ChangerScenes()
    {
        SceneManager.LoadScene("NextScene");
    }
    public void ReSpawn()
    {
        SceneManager.LoadScene(scene);
    }
}

