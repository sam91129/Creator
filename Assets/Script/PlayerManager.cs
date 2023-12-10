using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    //���ʩһ��ܼ�
    [Header("���ʳ]�m")]
    CharacterController _characterController;
    public float walk;
    public float run;
    float speed;
    public float jump;
    public float superJump;
    GameObject _groundCheck;
    public LayerMask _groundMask;
    public float Gravity;
    Vector2 MoveValue;
    Vector3 Move;
    Vector3 Velocity = Vector3.zero;

    //�ƹ���w%����һ��ܼ�
    [Header("���Y��ʳ]�m")]
    public float MouseSensitivity;     //�ṳ���W�U����X�ܤƶq
    float xRotation = 0f;
    Vector2 MouseValue;
    public Transform _playerBody;
    public Camera _camera;

    //�a���T�{�һ��ܼ�
    [Header("�a���˴�")]
    public static bool isGrounded;

    //���u�˴��һ��ܼ�
    [Header("�Ǥ߳]�m")]
    [SerializeField] float maxGloveDistance = 10.0f;
    [SerializeField] float maxSwitchDistance = 5.0f;
    [SerializeField] float vistionRadius = 0.1f;
    [SerializeField] LayerMask _switchMask;
    float MouseX;
    float MouseY;
    Vector3 CrossOrigin;
    Vector3 CrossDirection;
    RaycastHit _hits;

    [Header("��O�]�m")]
    public bool HadGloves;
    int limitObject = 1;
    int Energy;
    int ObjectNumber;
    GameObject[] _gameObject;
    bool isRepeat;
    bool inSwitch = false;

    [Header("��q")]
    public int Hp;
    Event_Hurtplace Event_Hurtplace;
    void Awake()
    {
        _gameObject = new GameObject[99];
        _characterController = GetComponent<CharacterController>();
        _groundCheck = GameObject.FindGameObjectWithTag("GroundCheck");
        Cursor.lockState = CursorLockMode.Locked;   //�W�U���W�L90�� 
        speed = walk;
        Event_Hurtplace = GameObject.FindWithTag("HurtEffect").GetComponent<Event_Hurtplace>();
    }
    void Update()
    {
        groundCheck();
        if (MoveValue != Vector2.zero)
        {
            Move = transform.right * MoveValue.x + transform.forward * MoveValue.y;
            _characterController.Move(Move * speed * Time.deltaTime);
        }       //onMove
        if (isGrounded == true && Velocity.y < 0) Velocity.y = 0;
        Velocity.y -= Gravity * Time.deltaTime;
        _characterController.Move(Velocity * Time.deltaTime);
        if (MouseValue != Vector2.zero)
        {
            xRotation -= MouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);                                  //�Y����90��
            _camera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);          //
            _playerBody.Rotate(Vector3.up * MouseX);
        }      //onVision
    }
    public void onVision(InputAction.CallbackContext ctx)
    {
        MouseValue = ctx.ReadValue<Vector2>();
        MouseX = MouseValue.x * MouseSensitivity * Time.deltaTime; ;  //¶X�b����
        MouseY = MouseValue.y * MouseSensitivity * Time.deltaTime; ;  //¶Y�b����
    }
    public void onMove(InputAction.CallbackContext ctx)    
    {
        MoveValue = ctx.ReadValue<Vector2>();
    }
    public void onRun(InputAction.CallbackContext ctx)
    {
        if (ctx.started) speed = run;
        if (ctx.canceled) speed = walk;
    }
    public void onJump(InputAction.CallbackContext ctx)
    {
        if (ctx.started && isGrounded == true)
        {
            Velocity.y += Mathf.Sqrt(jump * 2 * Gravity);
        }
    }
    public void onUse(InputAction.CallbackContext ctx)
    {
        if(ctx.started && HadGloves)
        {
            CrossOrigin = _camera.transform.position;
            CrossDirection = _camera.transform.forward;
            if (Physics.SphereCast(CrossOrigin, vistionRadius, CrossDirection, out _hits, maxGloveDistance) && _hits.collider.tag == ("ScaleWall"))
            {
                repeatCheck();
                if (!isRepeat)
                {
                    if (_gameObject[ObjectNumber] != null) _gameObject[ObjectNumber].GetComponent<Mech_ScaleWall>().Revert();
                    _gameObject[ObjectNumber] = _hits.collider.gameObject;
                    _gameObject[ObjectNumber].GetComponent<Mech_ScaleWall>().WallChangeScale();
                    ObjectNumber++;
                    if (ObjectNumber >= limitObject) ObjectNumber = 0;
                }
                else isRepeat = false;
            }
        }
    }
    public void onCancel(InputAction.CallbackContext ctx)
    {
        if (ctx.started && HadGloves)
        {
            CrossOrigin = _camera.transform.position;
            CrossDirection = _camera.transform.forward;
            if (Physics.SphereCast(CrossOrigin, vistionRadius, CrossDirection, out _hits, maxGloveDistance) && _hits.collider.tag == ("JumpPad"))
            {
                _hits.collider.GetComponent<Mech_JumpPad>().WallChargeJump();
            }
        }
    }
    public void onSwitch(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            CrossOrigin = _camera.transform.position;
            CrossDirection = _camera.transform.forward;
            if (Physics.SphereCast(CrossOrigin, vistionRadius, CrossDirection, out _hits, maxSwitchDistance, _switchMask) && inSwitch)
            {
                _hits.collider.gameObject.GetComponent<Mech_Switch>().useSwitch();
            }
            if (Physics.SphereCast(CrossOrigin, vistionRadius, CrossDirection, out _hits, maxSwitchDistance))
            {
                if (_hits.collider.tag == "Gloves")
                {
                    HadGloves = true;
                    _hits.collider.gameObject.SetActive(false);
                }
            }
        }
    }
    public void Damageplayer(int damage)
    {
        Event_Hurtplace.FlashScreen();
        Hp -= damage;
        if (Hp <= 0)
        {
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().ReSpawn();
        }
    }
    void groundCheck()
    {
        isGrounded = Physics.CheckSphere(_groundCheck.transform.position, 0.1f, _groundMask);
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
        limitObject = 1 + Energy;
        if (_gameObject[ObjectNumber] != null) ObjectNumber++;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Energy")
        {           
            Energy++;
            count();
            Destroy(other.gameObject);
        }
        if (other.tag == "SwitchRange")
        {
            inSwitch = true;
        }
        if(other.tag == "SuperJump")
        {
            Velocity += new Vector3( 0, superJump, 0);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "SwitchRange")
        {
            inSwitch = false;
        }
    }
    /*void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(CrossOrigin, CrossDirection);
        Gizmos.DrawWireSphere(CrossOrigin + CrossDirection * _hits.distance, vistionRadius);
    }*/
}
