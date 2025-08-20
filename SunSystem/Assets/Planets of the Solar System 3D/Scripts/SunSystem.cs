using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunSystem : MonoBehaviour
{
    [Tooltip("太阳")]
    public GameObject sun; 
    [Tooltip("水星")]
    public GameObject mercury;
    [Tooltip("金星")]
    public GameObject venus; 
    [Tooltip("地球")]
    public GameObject earth;
    [Tooltip("火星")]
    public GameObject mars;
    [Tooltip("木星")]
    public GameObject jupiter;
    [Tooltip("土星")]
    public GameObject saturn;
    [Tooltip("天王星")]
    public GameObject uranus;
    [Tooltip("海王星")]
    public GameObject neptune;
    [Tooltip("冥王星")]
    public GameObject pluto; 
    [Tooltip("月球")]
    public GameObject moon;
    // Start is called before the first frame update


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 地球自转
        earth.transform.Rotate(Vector3.up, 8f * Time.deltaTime);
        // 月球公转
        moon.transform.RotateAround(earth.transform.position, Vector3.up, 24f * Time.deltaTime);
        // 地球公转
        earth.transform.RotateAround(sun.transform.position, Vector3.up, 1f * Time.deltaTime);
        // 金星公转
        venus.transform.RotateAround(sun.transform.position, Vector3.up, 1f * Time.deltaTime);
        // 火星公转
        mars.transform.RotateAround(sun.transform.position, Vector3.up, 1f * Time.deltaTime);
        // 木星公转
        jupiter.transform.RotateAround(sun.transform.position, Vector3.up, 1f * Time.deltaTime);
        // 土星公转
        saturn.transform.RotateAround(sun.transform.position, Vector3.up, 1f * Time.deltaTime);
        // 天王星公转
        uranus.transform.RotateAround(sun.transform.position, Vector3.up, 1f * Time.deltaTime);
        // 海王星公转
        neptune.transform.RotateAround(sun.transform.position, Vector3.up, 1f * Time.deltaTime);
        // 冥王星公转
        pluto.transform.RotateAround(sun.transform.position, Vector3.up, 1f * Time.deltaTime);
        // 水星公转
        mercury.transform.RotateAround(sun.transform.position, Vector3.up, 1f * Time.deltaTime);
        // 太阳自转
        sun.transform.Rotate(Vector3.up, 1f * Time.deltaTime);
    }
}
