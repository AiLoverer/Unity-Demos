using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusController : MonoBehaviour
{
    // 分数
    public static int score = 0;
    // 生命值
    public static int life = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 打印当前分数
        Debug.Log("Score: " + score);
        // 打印当前生命值    
        Debug.Log("Life: " + life);
    }
}
