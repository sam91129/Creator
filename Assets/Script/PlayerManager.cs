using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using FMODUnity;


public class PlayerManager : MonoBehaviour
{
    gameManager gameManager;
    bool isPause;
    //移動所需變數
    [Header("移動設置")]
    CharacterController _characterController;
    public float walk;
    public float run;
    bool isRun;
    float speed;
    public float jump;
    public float superJump;
    GameObject _groundCheck;
    GameObject _topCheck;
    public LayerMask _groundMask;
    public LayerMask _topMask;
    public float Gravity;
    Vector2 MoveValue;
    Vector3 Move;
    Vector3 Velocity = Vector3.zero;
    private FMOD.Studio.EventInstance WalkAudio;
    public FMODUnity.EventReference Walk;
    private FMOD.Studio.EventInstance RunAudio;
    public FMODUnity.EventReference Run;
    //public AudioSource MoveAudio;

    //滑鼠鎖定%控制所需變數
    [Header("鏡頭轉動設置")]
    public float MouseSensitivity;     //攝像機上下選轉X變化量
    float xRotation = 0f;
    Vector2 MouseValue;
    public Transform _playerBody;
    public Camera _camera;

    //地面確認所需變數
    [Header("地面檢測")]
    public static bool isGrounded;

    //視線檢測所需變數
    [Header("準心設置")]
    [SerializeField] float maxGloveDistance = 10.0f;
    [SerializeField] float maxSwitchDistance = 5.0f;
    [SerializeField] float vistionRadius = 0.1f;
    [SerializeField] LayerMask _glovesMask;
    [SerializeField] LayerMask _switchMask;
    float MouseX;
    float MouseY;
    Vector3 CrossOrigin;
    Vector3 CrossDirection;
    RaycastHit _hits;

    [Header("能力設置")]
    public bool HadGloves;
    Animator _animator;
    public GameObject _rArmModel;
    //public GameObject _glovesModel;
    int limitObject = 1;
    int ObjectNumber;
    GameObject[] _gameObject;
    bool isRepeat;
    bool inSwitch = false;
    int bridgeRemain;

    [Header("血量")]
    public int MaxHp;
    int Hp;
    Event_Hurtplace Event_Hurtplace;
    public Vector3 ReSpawnPoint;

    void Awake()
    {
        _animator = _rArmModel.GetComponent<Animator>();
        if (!HadGloves) _animator.SetBool("HadGrove", false);
        else _animator.SetBool("HadGrove", true);
        _gameObject = new GameObject[99];
        _characterController = GetComponent<CharacterController>();
        _groundCheck = GameObject.FindGameObjectWithTag("GroundCheck");
        _topCheck = GameObject.FindGameObjectWithTag("TopCheck");
        Cursor.lockState = CursorLockMode.Locked;   //上下不超過90度 
        speed = walk;
        Event_Hurtplace = GameObject.FindWithTag("HurtEffect").GetComponent<Event_Hurtplace>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<gameManager>();
        WalkAudio = FMODUnity.RuntimeManager.CreateInstance(Walk);
        RunAudio = FMODUnity.RuntimeManager.CreateInstance(Run);

        setSensitivity();
    }
    void Start()
    {
        bridgeRemain = limitObject;
        brigheCount();
        gameManager.current.whenRespawn += ReSet;
        Physics.IgnoreLayerCollision(3, 3, true);
        isRun = false;
        Hp = MaxHp;
    }
    void Update()
    {
        
        groundCheck();
        topCheck();
        if (MoveValue != Vector2.zero)
        {
                Move = transform.right * MoveValue.x + transform.forward * MoveValue.y;
            _characterController.Move(Move * speed * Time.deltaTime);
        }       //onMove
        else RunAudio.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);

        if (isGrounded == true && Velocity.y < 0) Velocity.y = 0;
        Velocity.y -= Gravity * Time.deltaTime;
        _characterController.Move(Velocity * Time.deltaTime);
        if (MouseValue != Vector2.zero)
        {
            xRotation -= MouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);                                  //頭部轉90度
            _camera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);          //
            _playerBody.Rotate(Vector3.up * MouseX);
        }      //onVision
    }
    public void onVision(InputAction.CallbackContext ctx)
    {
        MouseValue = ctx.ReadValue<Vector2>();
        MouseX = MouseValue.x * MouseSensitivity * 10 * Time.deltaTime; ;  //繞X軸旋轉
        MouseY = MouseValue.y * MouseSensitivity * 10 * Time.deltaTime; ;  //繞Y軸旋轉
    }
    public void onMove(InputAction.CallbackContext ctx)    
    {
        
        MoveValue = ctx.ReadValue<Vector2>();
        if(!isRun) WalkAudio.start();
        else RunAudio.start();
        if (ctx.canceled) WalkAudio.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
    public void onRun(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        { 
            speed = run;
            isRun = true;
            WalkAudio.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            if (MoveValue != Vector2.zero) RunAudio.start();
        }
        if (ctx.canceled)
        {
            speed = walk;
            isRun = false;
            if (MoveValue != Vector2.zero)
            {
                WalkAudio.start();
                RunAudio.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            }
            RunAudio.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }
    public void onJump(InputAction.CallbackContext ctx)
    {
        if (ctx.started && isGrounded == true)
        {
            RuntimeManager.PlayOneShot("event:/Player/Event_jump");
            Velocity.y += Mathf.Sqrt(jump * 2 * Gravity);
        }
    }
    public void onUse(InputAction.CallbackContext ctx)
    {
        if(ctx.started && HadGloves)
        {
            CrossOrigin = _camera.transform.position;
            CrossDirection = _camera.transform.forward;
            Physics.SphereCast(CrossOrigin, vistionRadius, CrossDirection, out _hits, maxGloveDistance, _glovesMask);
            if (_hits.collider.tag == ("ScaleWall"))
            {
                repeatCheck();
                if (!isRepeat)
                {
                    if(bridgeRemain > 0) bridgeRemain--;
                    brigheCount();
                    if (_gameObject[ObjectNumber] != null) _gameObject[ObjectNumber].GetComponent<Mech_ScaleWall>().ReSet();
                    _gameObject[ObjectNumber] = _hits.collider.gameObject;
                    _gameObject[ObjectNumber].GetComponent<Mech_ScaleWall>().WallChangeScale();
                    ObjectNumber++;
                    if (ObjectNumber >= limitObject) ObjectNumber = 0;
                }
                else isRepeat = false;
            }
        }
        if (ctx.performed && HadGloves)
        {
            for (int i = 0; i < limitObject; i++)
            {
                if (_gameObject[i] != null)
                {
                    _gameObject[i].GetComponent<Mech_ScaleWall>().ReSet();
                    _gameObject[i] = null;
                }
            }
            bridgeRemain = limitObject;
            brigheCount();
        }
    }
    public void onJumpPad(InputAction.CallbackContext ctx)
    {
        if (ctx.started && HadGloves)
        {
            CrossOrigin = _camera.transform.position;
            CrossDirection = _camera.transform.forward;
            Physics.SphereCast(CrossOrigin, vistionRadius, CrossDirection, out _hits, maxGloveDistance, _glovesMask);
            if (_hits.collider.tag == ("JumpPad"))
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
                    GameObject.FindGameObjectWithTag("GameManager").GetComponent<gameManager>()._bridge.enabled = true;
                    _animator.SetBool("HadGrove", true);
                    //_glovesModel.SetActive(true);
                    //_rArmModel.SetActive(false);
                    _hits.collider.gameObject.SetActive(false);
                }
            }
        }
    }
    public void onPause()
    {
        if(gameManager.canPause)
        {
            isPause = !isPause;
            if (isPause)
            {
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.Confined;
                gameManager._pause.SetActive(true);
            }
            else
            {
                gameManager._pause.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1.0f;
            }
        }
    }
    public void setSensitivity()
    {
        MouseSensitivity = PlayerPrefs.GetFloat("Sensitivity", 1.0f);
    }
    public void Damageplayer(int damage)
    {
        //MoveAudio.PlayOneShot(gameManager._HurtAudio);
        RuntimeManager.PlayOneShot("event:/Player/Event_hurt1");
        Event_Hurtplace.FlashScreen();
        Hp -= damage;
        if (Hp <= 0)
        {
            gameManager.ReSpawn();
        }
    }
    void groundCheck()
    {
        isGrounded = Physics.CheckSphere(_groundCheck.transform.position, 0.2f, _groundMask);
    }
    void topCheck()
    {
        if (Physics.CheckSphere(_topCheck.transform.position, 0.1f, _topMask))
        {
            if(Velocity.y>0) Velocity.y = 0;
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
    void brigheCount()
    {
        gameManager._bridge.text = bridgeRemain.ToString() + "/" + limitObject.ToString();
    }
    void count()
    {
        limitObject++;
        bridgeRemain++;
        if (_gameObject[ObjectNumber] != null) ObjectNumber++;
    }
    void ReSet()
    {
        Time.timeScale = 0;
        _characterController.enabled = false;
        this.gameObject.transform.position = ReSpawnPoint;
        Hp = MaxHp;
        for (int i = 0; i < limitObject; i++)
        {
            _gameObject[i] = null;
        }
        _characterController.enabled = true;
        Time.timeScale = 1;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Energy")
        {
            RuntimeManager.PlayOneShot("event:/Player/pick up energy");
            count();
            brigheCount();
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
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(CrossOrigin, CrossDirection);
        Gizmos.DrawWireSphere(CrossOrigin + CrossDirection * _hits.distance, vistionRadius);
    }
}
