using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Exit : MonoBehaviour
{
    public int NextScene;
    gameManager gameManager;
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<gameManager>();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            gameManager.Next = NextScene;
            gameManager.Pass();
        }
    }
}
