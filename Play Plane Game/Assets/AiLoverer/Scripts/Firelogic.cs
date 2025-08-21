using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firelogic : MonoBehaviour
{
    // 炮管
    public Transform gun;
    // 子弹出生点
    public Transform firePoint;
    // 子弹树
    public Transform fireFolder;
    public GameObject firePrefab;

    // 子弹速度
    public float bulletSpeed = 10f;
    // 子弹最大飞行时间
    public float bulletMaxTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            DoWork();
        }
    }

    void DoWork(){
        Debug.Log("--创建子弹--");
        GameObject fire = Object.Instantiate(firePrefab, fireFolder);
        fire.transform.position = firePoint.position;
        //fire.transform.localEulerAngles = Vector3.zero;
        fire.transform.eulerAngles = gun.eulerAngles;
        BulletLogic bulletLogic = fire.GetComponent<BulletLogic>();
        bulletLogic.speed = bulletSpeed;
        bulletLogic.maxDistance = bulletSpeed * bulletMaxTime;
    }
}
