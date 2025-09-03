using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 主界面UI控制器
/// </summary>
public class MainGUUIController : MonoBehaviour
{
    // 背包UI
    public GameObject inventorySystemUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 显示背包系统
    public void ShowInventorySystem()
    {
        Debug.Log("显示背包系统");
        if(inventorySystemUI== null)
        {
            Debug.Log("背包系统UI为空");
            return;
        }
        if(inventorySystemUI.activeSelf == false)
        {
            inventorySystemUI.SetActive(true);
        }else
        {
            inventorySystemUI.SetActive(false);
        }

    }

}
