using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TYFP : MonoBehaviour
{
    //int A = 0;
    float T = 5f;
    void Update()
    {
        T -= Time.deltaTime;
        print(T);
        if (T < 0) SceneManager.LoadScene(0);
    }
}
