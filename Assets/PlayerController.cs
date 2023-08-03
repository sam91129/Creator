using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //移動所需變數
    [Header("移動設置")]
    Rigidbody _playerRig;
    public float walk;
    public float run;
    float speed;
    public float jump;
    Vector2 moveValue;
    Vector3 move;

    //滑鼠鎖定%控制所需變數
    [Header("鏡頭轉動設置")]
    public float mouseSensitivity;     //攝像機上下選轉X變化量
    float xRotation = 0f;
    Vector2 mouseValue;
    public Transform playerbody;
    public Camera _camera;

    //地面確認所需變數
    [Header("地面檢測")]
    public SphereCollider _groundCheck;
    static public bool isGrounded;

    //視線檢測所需變數
    [Header("準心設置")]
    [SerializeField] private float _maxDistance = 10.0f;
    [SerializeField] float _vistionRadius = 0.1f;
    [SerializeField] LayerMask _layerMask;
    Vector3 _origin;
    Vector3 _direction;
    RaycastHit _hits;
    GameObject _gameObject;

    void Awake()
    {
        _playerRig = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;   //上下不超過90度 
        speed = walk;
    }
    void Update()
    {
        if (moveValue != Vector2.zero)
        {
            this.transform.position += move * speed * Time.deltaTime;
        }
        if (mouseValue != Vector2.zero)
        {
            float mouseX = mouseValue.x * mouseSensitivity * Time.deltaTime; ;  //繞X軸旋轉
            float mouseY = mouseValue.y * mouseSensitivity * Time.deltaTime; ;  //繞Y軸旋轉
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);                                  //頭部轉90度
            _camera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);          //
            playerbody.Rotate(Vector3.up * mouseX);
        }
        ViweCast();
    }
    public void onVision(InputAction.CallbackContext ctx)
    {
        mouseValue = ctx.ReadValue<Vector2>();
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
    public void onMove(InputAction.CallbackContext ctx)    
    {
            moveValue = ctx.ReadValue<Vector2>();
            move = transform.right * moveValue.x + transform.forward * moveValue.y;
    }
    public void onRun(InputAction.CallbackContext ctx)
    {
        if (ctx.started) speed = run;
        if (ctx.canceled) speed = walk;
    }
    public void onJump(InputAction.CallbackContext ctx)
    {
        if(isGrounded) if (ctx.started) _playerRig.AddForce(0, jump*100.0f , 0);
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
