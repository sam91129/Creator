using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   //���ʩһ��ܼ�
    public CharacterController controller;
    public float walk;
    public float run;
    public float gravity = -9.81f;//���O
    Vector3 velocity;

    //�ƹ���w%����һ��ܼ�
    [Header("Control Setting")]
    float mouseSensitivity = 100.0f;     //�ṳ���W�U����X�ܤƶq
    float xRotation = 0f;
    public Transform playerbody;
    public Camera _camera;

    //�a���T�{�һ��ܼ�
    public Transform groundCheck;
    public float grounDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;   //�W�U���W�L90�� 
    }

    void Update()
    {
        Movement(); //����
        Eye();      //�Ĥ@�H��
    }
    void Movement()
    {
        float x = Input.GetAxis("Horizontal");  //����
        float z = Input.GetAxis("Vertical");    //����
        Vector3 move = transform.right * x + transform.forward * z;
        if (Input.GetKey(KeyCode.LeftShift)) controller.Move(move * run * Time.deltaTime);
        else controller.Move(move * walk * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    void Eye()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime; ;  //¶X�b����
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime; ;  //¶Y�b����
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);                                  //�Y����90��
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
