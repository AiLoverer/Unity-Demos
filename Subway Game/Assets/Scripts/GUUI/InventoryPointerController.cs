using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// 背包指针控制脚本
/// </summary>
public class InventoryPointerController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 鼠标进入
    public void OnPointerEnter(PointerEventData eventData)
    {
        FollowPointer();
        if(InventorySystem.bagOnceTip.activeSelf == false)
            InventorySystem.bagOnceTip.SetActive(true);
        Debug.Log("鼠标移入");
        // 动态更新bagOnceTip中图片
        InventorySystem.bagOnceTip.transform.GetChild(1).GetComponent<Image>().sprite = this.transform.GetChild(0).GetComponent<Image>().sprite;
        // 动态更新bagOnceTip中文字
        InventorySystem.bagOnceTip.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = this.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text;
    }

    // 鼠标移除
    public void OnPointerExit(PointerEventData eventData)
    {
        if(InventorySystem.bagOnceTip.activeSelf == true)
            InventorySystem.bagOnceTip.SetActive(false);
        Debug.Log("鼠标移出");
    }

    // 鼠标点击
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("鼠标点击");
    }

    // bagOnceTip跟随鼠标滑动
    void FollowPointer()
    {
        Vector2 newPos;
        // 获取鼠标位置并转换为Canvas下的局部坐标
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            InventorySystem.bagOnceTip.transform.parent.transform as RectTransform, // 目标Canvas的RectTransform
            Input.mousePosition, // 鼠标的屏幕坐标
            null, // 对于Overlay模式，这里为null
            out newPos// 输出转换后的局部坐标
        );

        // 设置bagOnceTip的位置和偏移量
        InventorySystem.bagOnceTip.transform.localPosition = newPos +  new Vector2(InventorySystem.bagOnceTip.GetComponent<RectTransform>().rect.width/2f, -InventorySystem.bagOnceTip.GetComponent<RectTransform>().rect.height/2f);
    }
}
