using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mech_Laser : MonoBehaviour
{
    float maxLaserDistance = 100.0f;
    Vector3 LaserOrigin;
    Vector3 LaserDirection;
    RaycastHit _hit;
    LineRenderer _laserLine;

    public int demage;
    Player_Manager health;
    void Awake()
    {
        _laserLine = GetComponent<LineRenderer>();
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Manager>();
    }
    void Start()
    {
        LaserOrigin = transform.position;
        LaserDirection = transform.forward;
    }
    void FixedUpdate()
    {
        Laser();
    }
    void Laser()
    {
        Physics.Raycast(LaserOrigin, LaserDirection, out _hit, maxLaserDistance);
        {
            _laserLine.SetPosition(0, LaserOrigin);
            _laserLine.SetPosition(1,_hit.point);
            if (health != null && _hit.collider.tag == "Player")
            {
                health.Damageplayer(demage);
            }
        }
    }
}
