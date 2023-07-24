using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{

    [Header("移動")]
    [SerializeField] public float movespeed;
    [SerializeField] public float turnspeed;
    private float speed = 0f;
    private bool hasmoveinput;
    private Vector3 moveinput;
    private Vector3 lookDirection;

    [Header("跳躍")]
    [SerializeField] private float gravity = -20f;
    [SerializeField] private float jumpHeight = 2.5f;
    private Vector3 velocity;

    [Header("地板")]
    [SerializeField] private float groundCheckOffest = 0f;
    [SerializeField] private float groundCheckDistance = 0.4f;
    [SerializeField] private float groundCheckRadius = 0.25f;
    [SerializeField] private LayerMask groundMask;
   private bool isGrounded;


    private CharacterController charactercontroller;
    // Start is called before the first frame update

    public void Jump()
    {
        //確定在地板上
        if (!isGrounded) return;

        //計算加速度
        float jumpVelocity = Mathf.Sqrt(2f * -gravity * jumpHeight);
        velocity = new Vector3(0, jumpVelocity, 0);
    }
    
    //是否在地板上
    private bool CheckGround()
    {
        Vector3 start = transform.position + Vector3.up * groundCheckOffest;

        if(Physics.SphereCast(start,groundCheckRadius,Vector3.down,out RaycastHit hit, groundCheckDistance, groundMask))
        {
            return true;
        }
        return false;
    }
    private void OnDrawGizmosSelected()
    {
        //偵測顏色
        Gizmos.color = Color.red;
        if (isGrounded) Gizmos.color = Color.green;

        //測試 開始/結束的點
        Vector3 start = transform.position + Vector3.up * groundCheckOffest;
        Vector3 end = start + Vector3.down * groundCheckDistance;

        
    }

    private void Start()
    {
        charactercontroller = GetComponent<CharacterController>();
    }
    public void SetMoveInput(Vector3 input)
    {
        //確認是否按按鍵
        hasmoveinput = input.magnitude > 0.1f;
        moveinput = hasmoveinput ? input : Vector3.zero;
    }
    public void SetLookDirection(Vector3 move)
    {
        lookDirection = new Vector3(move.x, 0f, move.z).normalized;
    }
    private void FixedUpdate()
    {
        isGrounded = CheckGround();
        //跳躍
        velocity.y += gravity * Time.fixedDeltaTime;
        charactercontroller.Move(velocity * Time.fixedDeltaTime);

        speed = 0f;
        float targetRotation = 0f;
        if (moveinput.magnitude < 0.1f)
        {
            moveinput = Vector3.zero;
            return;
        }
        //移動判斷
        if (moveinput != Vector3.zero)
        {
            speed = movespeed;
        }

        charactercontroller.Move(moveinput * speed * Time.fixedDeltaTime);
    }
}
