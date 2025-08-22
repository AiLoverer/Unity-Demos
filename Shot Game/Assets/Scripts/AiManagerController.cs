using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AI判断敌人位置 在前方/后方/侧方
/// </summary>
/// <remarks>
/// 提示玩家敌人位置，后增加BUFF：护盾...
/// </remarks>
/// 
public class AiManagerController : MonoBehaviour
{
    
    // 玩家
    GameObject player;

    // 敌人
    GameObject[] enemies;
    
    // Start is called before the first frame update
    void Start()
    {
        // 查找玩家
        player = GameObject.FindGameObjectWithTag("Player");
        // 查找敌人
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        // 判断玩家和敌人是否存在
        if (enemies.Length == 0 || player == null)
        {
            return;
        }

        // 测试enemies[0]
        if(enemies[0] != null) {
            // 获取玩家指向敌人方向向量
            Vector3 playerToEnemyVector = enemies[0].transform.position - player.transform.position;
            // 归一化向量
            playerToEnemyVector.Normalize();

            // 绘制任务和敌人的连线
            Debug.DrawLine(player.transform.position, enemies[0].transform.position, Color.red);

            // 计算玩家和敌人之间的点乘
            float dotProduct = Vector3.Dot(player.transform.forward, playerToEnemyVector);
            // 敌人在前方
            if (dotProduct > 0.9f)
            {
                Debug.Log("敌人在前方");
            }
            // 敌人在后方
            else if (dotProduct < -0.9f)
            {
                Debug.Log("敌人在后方");
            }
            // 敌人在侧方
            else
            {
                Debug.Log("敌人在侧方");    
            }
        }
        
    }
}
