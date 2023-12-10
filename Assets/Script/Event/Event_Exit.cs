using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Exit : MonoBehaviour
{
    GameObject _sceneSystem;
    void Start()
    {
        _sceneSystem = GameObject.FindGameObjectWithTag("GameManager");
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _sceneSystem.GetComponent<gameManager>().ChangerScenes();
        }
    }
}
