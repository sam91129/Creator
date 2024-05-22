using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TYFP : MonoBehaviour
{
    float T = 5f;
    //int A = 0;
    private void Start()
    {
        Time.timeScale = 1.0f;
        
    }
    
    void Update()
    {
        T -= Time.deltaTime;
        print(T);
        if (T < 0) SceneManager.LoadScene(0);
    }
}
