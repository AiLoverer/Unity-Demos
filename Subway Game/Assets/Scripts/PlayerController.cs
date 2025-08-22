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
    // 最大跳跃次数
    public int maxJumpCount = 2;
    // 前进速度
    public float forwardSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 获取玩家的输入AD
        float horizontalInput = Input.GetAxis("Horizontal");
        // 获取玩家跳跃的输入
        float jumpInput = Input.GetAxis("Jump");

        // 左右/跳跃/前进移动
        transform.Translate(new Vector3(horizontalInput * leftRightSpeed, jumpInput * jumpSpeed, forwardSpeed)* Time.deltaTime);
    }
}
