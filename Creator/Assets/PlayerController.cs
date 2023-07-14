using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   //移動所需變數
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

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;   //上下不超過90度 
    }

    void Update()
    {
        Movement(); //移動
        Eye();      //第一人稱
    }
    void Movement()
    {
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
        _camera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
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
}
