using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    //移動所需變數
    public CharacterController controller;
    public float walk;
    public float run;
    public float gravity = -9.81f;//重力
    Vector3 velocity;

    //滑鼠鎖定%控制所需變數
    [Header("Control Setting")]
    float mouseSensitivity = 100.0f;     //攝像機上下選轉X變化量
    float xRotation = 0f;
    public Transform playerbody;
    public Camera _camera;

    //地面確認所需變數
    public Transform groundCheck;
    public float grounDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    //視線檢測所需變數
    [Header("Interaction Setting")]
    [SerializeField] private float _maxDistance = 10.0f;
    [SerializeField] float _vistionRadius = 0.1f;
    [SerializeField] LayerMask _layerMask;
    Vector3 _origin;
    Vector3 _direction;
    RaycastHit _hits;
    GameObject _gameObject;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;   //上下不超過90度 
    }

    void Update()
    {
        //Movement(); //移動
        GroundCheck();
        Eye();      //第一人稱
        ViweCast();

        //Debug.Log(_hits);
    }
    void Movement()    {
        float x = Input.GetAxis("Horizontal");  //平行
        float z = Input.GetAxis("Vertical");    //垂直
        Vector3 move = transform.right * x + transform.forward * z;
        if (Input.GetKey(KeyCode.LeftShift)) controller.Move(move * run * Time.deltaTime);
        else controller.Move(move * walk * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    void Eye()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime; ;  //繞X軸旋轉
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime; ;  //繞Y軸旋轉
        xRotation -= mouseY;                                                            
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);                                  //頭部轉90度
        _camera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);          //
        playerbody.Rotate(Vector3.up * mouseX);
    }
    void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, grounDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    }
    
    void ViweCast()
    {
        _origin = _camera.transform.position;
        _direction = _camera.transform.forward;

        if (Physics.SphereCast(_origin, _vistionRadius, _direction, out _hits, _maxDistance, _layerMask))
        {
            _gameObject = _hits.collider.gameObject;
        }
    }

    void UseItem()
    {
        //if (_gameObject != null && C)
        //{

        //}
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(_origin, _direction);
        Gizmos.DrawWireSphere(_origin + _direction * _hits.distance, _vistionRadius);
    }
}
