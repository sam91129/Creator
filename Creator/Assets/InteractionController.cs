using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    [Header("Interaction Setting")]
    [SerializeField] private float _maxDistance = 10.0f;
    [SerializeField] float _vistionRadius = 1.0f;
    [SerializeField] LayerMask _layerMask;
    public bool IsInteracted { get; set; }

    Vector3 _origin;
    Vector3 _direction;
    RaycastHit _hits;
    Transform _Item;

    void Update()
    {
        _origin = transform.position;
        _direction = transform.forward;

        if(Physics.SphereCast(_origin,_vistionRadius,_direction,out _hits,_maxDistance))
        {
            if (_hits.transform.TryGetComponent(out Interactable item) && IsInteracted)
            {
                _Item = _hits.transform;
                item.Interact();
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(_origin, _direction);
        Gizmos.DrawWireSphere(_origin + _direction * _hits.distance,_vistionRadius);
    }
}
