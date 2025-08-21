using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    // 子弹出生点
    public Transform firePoint;
    // 子弹树
    public Transform fireFolder;
    // 子弹预制体
    public GameObject firePrefab;

    // 子弹发射间隔
    public float fireInterval = 0.5f;

    // 按键控制移动速度
    public float moveSpeed = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", fireInterval, fireInterval);
    }

    // Update is called once per frame
    void Update()
    {
        float dx = 0;
        if(Input.GetKey(KeyCode.A)){
            Debug.Log("A");
            dx = -moveSpeed;
        }
        if(Input.GetKey(KeyCode.D)){
            dx = moveSpeed;
        }
        transform.Translate(dx, 0, 0, Space.Self);

        // W/S
        float dy = 0;
        if(Input.GetKey(KeyCode.W)){
            dy = -moveSpeed;
        }
        if(Input.GetKey(KeyCode.S)){
            dy = moveSpeed;
        }
        transform.Translate(0, dy, 0, Space.Self);
    }

    void Fire()
    {
        Debug.Log("Fire ...");
        GameObject fire = Object.Instantiate(firePrefab, fireFolder);
        fire.transform.position = firePoint.position;
        fire.transform.eulerAngles = transform.eulerAngles;
    }
}
