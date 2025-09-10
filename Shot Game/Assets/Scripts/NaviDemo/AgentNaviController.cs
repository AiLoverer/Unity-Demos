using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Agent 导航控制类
/// </summary>
/// <remarks>
/// 1. 实现Agent的导航功能:鼠标左键点击后Agent开始导航到鼠标点击的位置
/// </remarks>
public class AgentNaviController : MonoBehaviour
{
    // 存储目标点
    private Vector3 targetPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 获取鼠标点击
        if(Input.GetMouseButtonDown(0)) {
            Debug.Log("AgentNaviController:鼠标左键点击");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit)) {
                if(hit.transform.gameObject.tag != "Player") {
                    Debug.Log("AgentNaviController:导航到" + hit.point);
                    // 导航到点击位置
                    targetPoint = hit.point;
                }
                
            }
        }
        // 导航到目标点
        if(targetPoint!= Vector3.zero) {
            transform.Translate((targetPoint - transform.position) * Time.deltaTime, Space.World);
        }
    }
}
