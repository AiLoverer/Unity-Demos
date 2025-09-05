using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 这个类主要用于控制玩家的移动
/// </summary>
public class PlayerController : MonoBehaviour
{
    // 左右移动速度
    public float leftRightSpeed = 20f;
    // 跳跃速度
    public float jumpSpeed = 50f;
    public float jumpForce = 20.0f;  // 跳跃力（这个决定跳跃高度）
    // 最大跳跃次数
    //public int maxJumpCount = 2;
    // 前进速度
    public float forwardSpeed = 10f;
    private Rigidbody rb; // 引用刚体组件
    private bool isGrounded = true; // 新增：是否在地面上的标志位
    // 获取Animator组件
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // 获取玩家的输入AD
        float horizontalInput = Input.GetAxis("Horizontal");
        // 获取玩家跳跃的输入
        float jumpInput = Input.GetAxis("Jump");
        if(jumpInput > 0) {
            animator.SetInteger("RunToJump", 2);
            Debug.Log("jumpInput > 0");
        }

        // 空格键抬起时，取消跳跃
        if (jumpInput <= 0) {
            animator.SetInteger("RunToJump", 0);
            Debug.Log("jumpInput < 0");
        }

        // //用户按下S键，切换到下滑
        // if (Input.GetKeyDown(KeyCode.S))
        // {
        //     animator.SetInteger("RunToScroll",3);
        //     Debug.Log("KeyCode.S");
        // }
        // // S键抬起时: 取消了S键切换到下滑的功能
        // if (Input.GetKeyUp(KeyCode.S))
        // {
        //     animator.SetInteger("RunToScroll", 0);
        //     Debug.Log("KeyCode.S up");
        // }
        // 获取垂直输入
        float verticalInput = Input.GetAxis("Vertical");

        // 用户按下S键，切换到下滑
        if (verticalInput > 0) {
            animator.SetInteger("RunToScroll", 3);
            Debug.Log("VerticalInput > 0 (S键按下)");
        }

        // S键抬起时: 取消了S键切换到下滑的功能
        if (verticalInput <= 0) {
            animator.SetInteger("RunToScroll", 0);
            Debug.Log("VerticalInput <= 0 (S键抬起)");
        }

        // 左右/跳跃/前进移动
        transform.Translate(new Vector3(horizontalInput * leftRightSpeed, jumpInput * jumpSpeed, forwardSpeed)* Time.deltaTime);
        //transform.Translate(new Vector3(horizontalInput * leftRightSpeed, 0f, forwardSpeed)* Time.deltaTime);
    }

    // void Jump()
    // {
    //     rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
    //     // 给刚体一个瞬间的、向上的力来实现跳跃
    //     rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    // }

    // // 新增：碰撞检测方法
    // private void OnCollisionEnter(Collision collision)
    // {
    //     // 判断碰撞的物体是否是地面（通常给地面物体Tag设为"Ground"）
    //     if (collision.gameObject.CompareTag("Ground") || collision.gameObject.name.Contains("Collider"))
    //     {
    //         isGrounded = true;
    //         Debug.Log("OnCollisionEnter isGrounded " + isGrounded + " Collider name :" + collision.gameObject.name);
    //     }
    // }

    // // 新增：防止从边缘起跳时误判
    // private void OnCollisionExit(Collision collision)
    // {
    //     if (collision.gameObject.CompareTag("Ground") || collision.gameObject.name.Contains("Collider"))
    //     {
    //         isGrounded = false;
    //         Debug.Log("OnCollisionExit isGrounded " + isGrounded + " Collider name :" + collision.gameObject.name);
    //     }
    // }
}
