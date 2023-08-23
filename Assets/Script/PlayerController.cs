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
    CharacterController _characterController;
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
    static public bool isGrounded;

    //視線檢測所需變數
    [Header("準心設置")]
    [SerializeField] float _maxGloveDistance = 10.0f;
    [SerializeField] float _maxSwitchDistance = 5.0f;
    [SerializeField] float _vistionRadius = 0.1f;
    [SerializeField] LayerMask _GloveMask;
    [SerializeField] LayerMask _SwitchMask;
    float mouseX;
    float mouseY;
    Vector3 _origin;
    Vector3 _direction;
    RaycastHit _hits;

    [Header("能力設置")]
    int limitObject = 1;
    int energy;
    int objectNumber;
    GameObject[] _gameObject;
    string[] _saveObject;
    bool isQuick;
    bool isRepeat;
    bool inSwitch = false;

    void Awake()
    {
        _gameObject = new GameObject[99];
        _characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;   //上下不超過90度 
        speed = walk;
    }
    void Update()
    {
        Debug.Log(move);
        if (moveValue != Vector2.zero)
        {
            move = transform.right * moveValue.x + transform.forward * moveValue.y;
            _characterController.Move(move * speed * Time.deltaTime);
        }       //onMove
        if (mouseValue != Vector2.zero)
        {
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);                                  //頭部轉90度
            _camera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);          //
            playerbody.Rotate(Vector3.up * mouseX);
        }      //onVision
    }
    public void onVision(InputAction.CallbackContext ctx)
    {
        mouseValue = ctx.ReadValue<Vector2>();
        mouseX = mouseValue.x * mouseSensitivity * Time.deltaTime; ;  //繞X軸旋轉
        mouseY = mouseValue.y * mouseSensitivity * Time.deltaTime; ;  //繞Y軸旋轉
    }
    public void onMove(InputAction.CallbackContext ctx)    
    {
        moveValue = ctx.ReadValue<Vector2>();
    }
    public void onRun(InputAction.CallbackContext ctx)
    {
        if (ctx.started) speed = run;
        if (ctx.canceled) speed = walk;
    }
    public void onJump(InputAction.CallbackContext ctx)
    {
        if(isGrounded) if (ctx.started) ;
    }
    public void onUse(InputAction.CallbackContext ctx)
    {
        if(ctx.performed) isQuick = true;
        if(ctx.canceled)
        {
            _origin = _camera.transform.position;
            _direction = _camera.transform.forward;
            if (Physics.SphereCast(_origin, _vistionRadius, _direction, out _hits, _maxGloveDistance, _GloveMask))
            {
                repeatCheck();
                if (!isRepeat)
                {
                    Debug.Log("pass");
                    if (_gameObject[objectNumber] != null) _gameObject[objectNumber].GetComponent<Wall_System>().Revert();
                    _gameObject[objectNumber] = _hits.collider.gameObject;
                    if (isQuick)
                    {
                        _gameObject[objectNumber].GetComponent<Wall_System>().QuickChangeScale();
                        isQuick = false;
                    }
                    else _gameObject[objectNumber].GetComponent<Wall_System>().NormalChangeScale();
                    objectNumber++;
                    if (objectNumber >= limitObject) objectNumber = 0;
                }
                else isRepeat = false;
            }
        }
    }
    public void onSwitch(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            _origin = _camera.transform.position;
            _direction = _camera.transform.forward;
            if (Physics.SphereCast(_origin, _vistionRadius, _direction, out _hits, _maxSwitchDistance, _SwitchMask) && inSwitch)
            {
                _hits.collider.gameObject.GetComponent<Mech_Switch>().useSwitch();
            }
        }
    }
    public void onCancel(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            for (int i = 0; i < limitObject; i++)
            {
                if (_gameObject[i] != null)
                {
                    _gameObject[i].GetComponent<Wall_System>().Revert();
                    _gameObject[i] = null;
                }
            }
            objectNumber = 0;
        }
    }
    void repeatCheck()
    {
        for (int i = 0; i < limitObject; i++)
        {
            if (_gameObject[i] != null)
            {
                if (_gameObject[i] == _hits.collider.gameObject) isRepeat = true;
            }
        }
    }
    void count()
    {
        limitObject = 1 + energy;
        if (_gameObject[objectNumber] != null) objectNumber++;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Energy")
        {
            energy++;
            count();
            Destroy(other.gameObject);
        }
        if (other.tag == "SwitchRange")
        {
            inSwitch = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "SwitchRange")
        {
            inSwitch = false;
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(_origin, _direction);
        Gizmos.DrawWireSphere(_origin + _direction * _hits.distance, _vistionRadius);
    }
}
