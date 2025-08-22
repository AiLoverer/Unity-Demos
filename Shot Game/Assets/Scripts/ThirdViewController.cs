using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 第三个视图控制器
/// </summary>
/// <remarks>
/// 动态追踪第三个视图控制器
/// </remarks>
public class ThirdViewController : MonoBehaviour
{
    // 第三视角摄像机
    public Camera thirdCamera;
    // 摄像机跟踪点
    public GameObject followPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        thirdCamera.transform.position = Vector3.Lerp(thirdCamera.transform.position, followPoint.transform.TransformPoint(0, 1, -3), 0.1f);
        thirdCamera.transform.LookAt(followPoint.transform);
    }
}
