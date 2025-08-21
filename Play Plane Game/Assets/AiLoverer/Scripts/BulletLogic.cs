using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    // 爆炸特效
    public GameObject explosionEffect;
    // 子弹最大飞行距离
    public float maxDistance = 5f;
    // 子弹初始速度
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        // 子弹飞行时间
        float time = maxDistance / speed;
        Invoke("DestroyBullet", time);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-Vector3.up * speed * Time.deltaTime);
    }

    void DestroyBullet()
    {
        Debug.Log("子弹飞行时间到，销毁子弹");
        if(gameObject != null){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {

         // 播放爆炸特效
        GameObject effect = Instantiate(explosionEffect, null);
        effect.transform.position = transform.position;

        //判断gameObject是否有效
        if(other.gameObject != null){
            if(other.name.StartsWith("Enemy")){
            Debug.Log("子弹碰撞到敌人");
            Destroy(other.gameObject);
        }
        }
        if(this.transform.gameObject != null){
            Debug.Log("子弹碰撞到物体");
            Destroy(this.transform.gameObject);
        }
    }
}
