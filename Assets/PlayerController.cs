using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //���ʩһ��ܼ�
    [Header("���ʳ]�m")]
    Rigidbody _playerRig;
    public float walk;
    public float run;
    float speed;
    public float jump;
    Vector2 moveValue;
    Vector3 move;

    //�ƹ���w%����һ��ܼ�
    [Header("���Y��ʳ]�m")]
    public float mouseSensitivity;     //�ṳ���W�U����X�ܤƶq
    float xRotation = 0f;
    Vector2 mouseValue;
    public Transform playerbody;
    public Camera _camera;

    //�a���T�{�һ��ܼ�
    [Header("�a���˴�")]
    public SphereCollider _groundCheck;
    static public bool isGrounded;

    //���u�˴��һ��ܼ�
    [Header("�Ǥ߳]�m")]
    [SerializeField] private float _maxDistance = 10.0f;
    [SerializeField] float _vistionRadius = 0.1f;
    [SerializeField] LayerMask _layerMask;
    Vector3 _origin;
    Vector3 _direction;
    RaycastHit _hits;

    [Header("��O�]�m")]
    int limitObject = 1;
    int energy;
    int objectNumber;
    GameObject[] _gameObject;
    string[] _saveObject;
    bool isQuick;
    bool isRepeat;

    void Awake()
    {
        _gameObject = new GameObject[99];
        _playerRig = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;   //�W�U���W�L90�� 
        speed = walk;
    }
    void Update()
    {
        if (moveValue != Vector2.zero)
        {
            this.transform.position += move * speed * Time.deltaTime;
        }       //onMove
        if (mouseValue != Vector2.zero)
        {
            float mouseX = mouseValue.x * mouseSensitivity * Time.deltaTime; ;  //¶X�b����
            float mouseY = mouseValue.y * mouseSensitivity * Time.deltaTime; ;  //¶Y�b����
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);                                  //�Y����90��
            _camera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);          //
            playerbody.Rotate(Vector3.up * mouseX);
        }      //onVision
    }
    public void onVision(InputAction.CallbackContext ctx)
    {
        mouseValue = ctx.ReadValue<Vector2>();
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
    public void onUse(InputAction.CallbackContext ctx)
    {
        if(ctx.performed) isQuick = true;
        if(ctx.canceled)
        {
            _origin = _camera.transform.position;
            _direction = _camera.transform.forward;
            if (Physics.SphereCast(_origin, _vistionRadius, _direction, out _hits, _maxDistance, _layerMask))
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
    public void onCancel(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            for (int i = 0; i < limitObject; i++)
            {
                _gameObject[i].GetComponent<Wall_System>().Revert();
                _gameObject[i] = null;
            }
            objectNumber = 0;
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
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(_origin, _direction);
        Gizmos.DrawWireSphere(_origin + _direction * _hits.distance, _vistionRadius);
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
}
