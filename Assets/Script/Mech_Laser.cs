using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mech_Laser : MonoBehaviour
{
    float maxLaserDistance = 100.0f;
    float LaserRadius = 0.1f;
    public LayerMask _playerMask;
    Vector3 LaserOrigin;
    Vector3 LaserDirection;
    RaycastHit _hit;

    public int demage;
    Player_Manager health;
    void Awake()
    {
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
        Physics.SphereCast(LaserOrigin, LaserRadius, LaserDirection, out _hit, maxLaserDistance);
        {
            if (health != null && _hit.collider.tag == "Player")
            {
                health.Damageplayer(demage);
            }
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(LaserOrigin, LaserDirection);    
        Gizmos.DrawWireSphere(LaserOrigin + LaserDirection * _hit.distance, LaserRadius);
    }

}
