using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家控制器。
/// </summary>
/// <remarks>
/// 附着于玩家对象上，负责控制玩家的移动、行为和动画表现。
/// 主要功能包括：
/// <list type="bullet">
/// <item><description>使用WSAD键控制玩家移动</description></item>
/// <item><description>使用空格键执行跳跃</description></item>
/// <item><description>使用鼠标左键进行射击</description></item>
/// <item><description>控制玩家的动画状态</description></item>
/// <item><description>根据鼠标输入旋转玩家朝向</description></item>
/// <item><description>使用鼠标滚轮调整玩家缩放</description></item>
/// </list>
/// </remarks>
public class PlayerController : MonoBehaviour
{
    // 玩家头部
    public GameObject playerHead;
    // 玩家旋转X角度
    float playerRotationX;
    // 玩家旋转Y角度
    float playerRotationY;
    // 鼠标旋转速率[灵敏度]
    public float mouseSensitivity = 6.0f;
    GameObject player;
    // 玩家旋转角度
    private float xRotation = 0f;
    // 玩家旋转角度
    private float yRotation = 0f;

    // 摄像头相机
    public Camera playerCamera;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if(player == null)
        {
            Debug.LogError("Player not found");
            return;
        }

        // 初始化玩家旋转角度
        playerRotationX = player.transform.rotation.x;
        playerRotationY = player.transform.rotation.y;
    }

    // Update is called once per frame
    void Update()
    {
        // 移动玩家
        MovePlayer();

        // 射击
        Shoot();
        
    }

    // 移动玩家
    void MovePlayer() {
        // 移动Palyer WASD
        if(Input.GetAxis("Horizontal") != 0)
        {
            player.transform.Translate(Vector3.right * Input.GetAxis("Horizontal"));
        }
        if(Input.GetAxis("Vertical") != 0)
        {
            player.transform.Translate(Vector3.forward * Input.GetAxis("Vertical"));
        }

        //鼠标滑动转动Plaer
        if(Input.GetAxis("Mouse X") != 0) // 鼠标水平移动
        {
            //player.transform.Rotate(Vector3.up, mouseSensitivity * Input.GetAxis("Mouse X") * Time.deltaTime * 100);
            playerRotationY += Input.GetAxis("Mouse X") * mouseSensitivity ; // 绕Y轴旋转
        }
        if(Input.GetAxis("Mouse Y") != 0) // 鼠标上下移动
        {
            //player.transform.Rotate(Vector3.right, mouseSensitivity *Input.GetAxis("Mouse Y") * Time.deltaTime * 100);
            playerRotationX -= Input.GetAxis("Mouse Y") * mouseSensitivity ; // 绕X轴旋转
        }

        // 限定玩家旋转角度
        playerRotationX = Mathf.Clamp(playerRotationX, -90f, 30f);
        //playerRotationY = Mathf.Clamp(playerRotationY, -90f, 90f);

        // 上下旋转玩家头部
        playerHead.transform.rotation = Quaternion.Euler(playerRotationX, playerRotationY, 0f);
        // 更新玩家旋转角度
        player.transform.rotation = Quaternion.Euler(0, playerRotationY, 0f);
    }

    // 玩家发射子弹
    public void Shoot() {
        // 鼠标左键按下发射射线
        if(Input.GetMouseButtonDown(0)) {
            Debug.Log("鼠标左键按下");

            // 获取摄像机和屏幕中心点的射线
            Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 10.0f));

            // 发射Ray  
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))          
            {
                Debug.Log("屏幕中心点射线碰撞到物体: " + hit.collider.name);
                // 判断物体Tag是否为Enemy
                if(hit.collider.tag == "Enemy")
                {
                    // 销毁物体
                    Destroy(hit.collider.gameObject);
                }
            }

            // 绘制Ray
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 100.0f, false);
        }
    }
    
}
