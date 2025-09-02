using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 登录控制器
/// </summary>
public class LoginController : MonoBehaviour
{
    // 注册面板组件
    public GameObject registerPanel;
    // 登录面板组件
    public GameObject loginPanel;
    // 提示信息组件
    public GameObject tipsPanel;
    // Start is called before the first frame update
    void Start()
    {
        registerPanel.SetActive(true);
        loginPanel.SetActive(false);
        tipsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 显示提示界面
    public void ShowTipsPanel()
    {
        if (registerPanel!= null)
            registerPanel.SetActive(false);
        if (tipsPanel!= null)
            tipsPanel.SetActive(true);
    }

    // 显示登录界面
    public void ShowLoginPanel()
    {
        if (loginPanel!= null)
            loginPanel.SetActive(true);
        if (tipsPanel!= null)
            tipsPanel.SetActive(false);
    }

    // 加载主界面
    public void LoadMainScene()
    {
        loginPanel.SetActive(false);
        SceneManager.LoadScene("Paoku2024");
    }

}
