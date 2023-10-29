using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mech_Laser : MonoBehaviour
{
    public float maxLaserDistance;
    Vector3 LaserOrigin;
    Vector3 LaserDirection;
    RaycastHit _hit;
    LineRenderer _laserLine;
    public bool open;
    public int demage;
    Player_Manager health;

    [Header("����ID")]
    public int ID;
    [Header("�P����")]
    public bool LoopType;
    public float openTime;
    public float closeTime;
    void Awake()
    {
        _laserLine = GetComponent<LineRenderer>();
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Manager>();
    }
    void Start()
    {
        if (LoopType) StartCoroutine(TimerLaser());
        Event_Manager.current.onSwitchUse += switchLaser;
    }
    void FixedUpdate()
    {
        LaserOrigin = transform.position;
        LaserDirection = transform.forward;
        if(open)
        {
            _laserLine.enabled = true;
            Laser();
        }
        else _laserLine.enabled = false;
    }
    void Laser()
    {
        Physics.Raycast(LaserOrigin, LaserDirection, out _hit, maxLaserDistance);
        {
            _laserLine.SetPosition(0, LaserOrigin);
            if (_hit.collider != null)
            {
                _laserLine.SetPosition(1, _hit.point);
                if (health != null && _hit.collider.tag == "Player")
                {
                    health.Damageplayer(demage);
                }
            }
            else _laserLine.SetPosition(1, LaserDirection*maxLaserDistance);
        }
    }
    public void switchLaser(int id)
    {
        if (id == this.ID) open = !open;
    }
    IEnumerator TimerLaser()
    {
        if (open) yield return new WaitForSeconds(openTime);
        else yield return new WaitForSeconds(closeTime);
        open = !open;
        StartCoroutine(TimerLaser());
    }
}
