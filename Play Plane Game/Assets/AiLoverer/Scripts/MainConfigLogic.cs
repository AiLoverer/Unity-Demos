using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainConfigLogic : MonoBehaviour
{
    public SimpleLogic simpleLogic;
    public AudioSource bgmAudio;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60; // 设置帧率60FPS
        bgmAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            DoWork();
        }
    }

    void DoWork(){
        simpleLogic.rotationSpeed = 180;
    }
}
