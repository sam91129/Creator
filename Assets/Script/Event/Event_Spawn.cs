using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Spawn : MonoBehaviour
{
    PlayerManager playerManager;
    GameObject _spawnPoint;
    void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        _spawnPoint = this.gameObject;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerManager.ReSpawnPoint = _spawnPoint.transform.position;
        }
    }
}
