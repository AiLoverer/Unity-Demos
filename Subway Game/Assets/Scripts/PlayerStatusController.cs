using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerStatusController : MonoBehaviour
{
    // 分数
    private static int score;
    // 分数UI组件
    public TextMeshProUGUI scoreTextMeshProUGUI;
    // 生命值
    private static int blood;
    // 生命值UI组件
    public Slider bloodSlider;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        blood = 100;
    }

    // Update is called once per frame
    void Update()
    {
        // 打印当前分数
        //Debug.Log("Score: " + score);
        // 打印当前生命值    
        //Debug.Log("Life: " + life);
        scoreTextMeshProUGUI.text = score.ToString();
        bloodSlider.value = blood;
    }

    /// <summary>
    /// 增加分数
    /// </summary>
    /// <param name="value"></param>
    public static void addScore(int value)
    {
        score += value;
        //Debug.Log("Score: " + score);
    }

    /// <summary>
    /// 减少生命值
    /// </summary>
    /// <param name="value"></param>
    public static void reduceBlood(int value)
    {
        blood -= value;
        Debug.Log("Bllod: " + blood);
    }

    /// <summary>
    /// 获取玩家分数
    /// </summary>
    /// <returns></returns>
    public static int getScore()
    {
        return score;
    }

    /// <summary>
    /// 获取玩家生命值
    /// </summary>
    /// <returns></returns>
    public static int getBlood()
    {
        return blood;
    }
}
