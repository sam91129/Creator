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
    PlayerManager health;
    bool respawn;

    [Header("周期型")]
    public bool isLoopType;
    public float openTime;
    public float closeTime;
    public bool startDelay;
    public float delayTime;
    [Header("機關ID")]
    public int ID;
    void Awake()
    {
        _laserLine = GetComponent<LineRenderer>();
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
    }
    void Start()
    {
        if (isLoopType) StartCoroutine(TimerLaser());
        gameManager.current.onSwitchUse += switchLaser;
        gameManager.current.whenRespawn += ReSet;
        respawn = open;
    }
    void ReSet()
    {
        open = respawn;
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
        if (startDelay)
        {
            yield return new WaitForSeconds(delayTime);
            startDelay = false;
        }
        if (open) yield return new WaitForSeconds(openTime);
        else yield return new WaitForSeconds(closeTime);
        open = !open;
        StartCoroutine(TimerLaser());
    }
}
