using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 金币克隆控制器
/// </summary>
/// <remarks>
/// 1. 克隆金币
/// 2. 销毁金币
/// 3. 碰撞检测
/// 4. 玩家死亡
/// </remarks>

public class CoinCloneController : MonoBehaviour
{

    // 金币模板
    public GameObject coinPrefab;
    // 克隆区域
    public GameObject[] cloneArea;
    // 存储金币父节点
    public GameObject coinParent;

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("检测到碰撞name " + collision.transform.gameObject.name);
        //Debug.Log("检测到碰撞tag " + collision.transform.gameObject.tag);
        if (collision.transform.gameObject.name == "CoinCollider001")
        {
            //Debug.Log("检测到克隆区域 CoinCollider001");
            CloneCoin(cloneArea[0]);
        }
        
        if(collision.transform.gameObject.name == "CoinCollider002") {
            //Debug.Log("检测到克隆区域 CoinCollider002");
            CloneCoin(cloneArea[1]);
        }

        // 销毁金币
        if(collision.transform.gameObject.tag == "Coin") {
            Destroy(collision.transform.gameObject);
            PlayerStatusController.addScore(10);
            //Debug.Log("检测到金币并销毁" + PlayerStatusController.getScore());
        }

        if(collision.transform.gameObject.name.Contains("CollDie")) {
            
            PlayerStatusController.reduceBlood(10);
            //Debug.Log("检测玩家碰到障碍物" + PlayerStatusController.getBlood());
        }

    }

    /// <summary>
    /// 克隆金币
    /// </summary>
    /// <param name="cloneArea">克隆区域</param>
    void CloneCoin(GameObject cloneArea) {
        int count = Random.Range(5, 21);
        //Debug.Log("随机克隆多个金币: " + count + " 个");
        for (int i = 0; i < count; i++) {
            GameObject coin = GameObject.Instantiate(coinPrefab, new Vector3(cloneArea.transform.position.x, cloneArea.transform.position.y, cloneArea.transform.position.z + i * 2f) , Quaternion.identity, coinParent.transform);
        }
    }

}
