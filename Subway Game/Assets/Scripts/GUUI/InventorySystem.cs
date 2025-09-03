using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// 背包系统
/// </summary>
/// <remarks>
/// 基础背包术语
/// Inventory - 背包/库存
/// Backpack - 背包
/// Bag - 袋子
/// Pouch - 小袋
/// Storage - 存储
/// </remarks>
public class InventorySystem : MonoBehaviour
{
    // 物品名称
    string[] itemChineseNames = {
    "灰色矿石", "金属部件", "蓝色水晶骷髅", "红色水晶碎片", "蓝色泪滴水晶", "红色水晶簇", "绿色水晶簇", "粉色水晶簇", "蓝色晶球", "浅蓝色水滴水晶",
    "深灰色矿石", "金属齿轮", "深蓝色部件", "灰色机械零件", "绿色机械零件", "彩虹色机械零件", "紫色漩涡宝石", "红色漩涡宝石", "紫色发光宝石", "橙色发光宝石",
    "紫色宝石", "蓝色宝石", "紫色漩涡宝石2", "蓝色漩涡宝石", "粉色漩涡宝石", "紫色刻面宝石", "蓝色漩涡贝壳", "绿色漩涡贝壳", "绿色宝石", "黄色宝石",
    "红色宝石", "紫色宝石2", "绿色漩涡宝石", "红色刻面宝石", "蓝色刻面宝石", "浅蓝色刻面宝石", "紫色漩涡宝石3", "绿色刻面宝石", "黄色漩涡宝石", "蓝色吊坠",
    "蓝色头盔", "绿色头盔", "黄色戒指", "绿色戒指", "金色戒指", "金色戒指2", "金色戒指3", "金色戒指4", "蓝色饰品", "镶蓝宝石的金戒指",
    "绿色吊坠", "绿色饰品", "红色吊坠", "绿色护甲", "绿色护甲2", "绿色钥匙", "粉色叶子饰品", "绿色叶子饰品", "紫色叶子饰品", "蓝色叶子饰品",
    "红色纱线", "绿色纱线", "红色圣诞帽", "棕色纱线", "紫色纱线", "红色布料", "银链", "灰色纱线", "金钥匙", "白色毛皮",
    "蓝色花纹木板", "棕色梳子", "棕色板条箱", "棕色陶罐", "棕色箱子", "棕色线圈", "棕色袋子", "白色茶壶", "白色罐子", "棕色卷轴",
    "红色药水瓶", "红色药水瓶2", "红色药水瓶3", "红色药水瓶4", "红色药水瓶5", "红色药水瓶小瓶", "红色药水罐", "红色药水包裹", "紫色药水小瓶", "紫色药水瓶",
    "紫色药水瓶2", "紫色药水瓶3", "紫色药水罐", "金色药水罐", "紫色药水包裹", "蓝色药水瓶", "蓝色药水罐", "金色药水瓶", "蓝色药水包裹"
    };
    // 物品精灵图片UI
    Sprite[] itemSprites;
    // 背包面板UI
    public GameObject bagPanel;
    // 背包预制体
    public GameObject bagPrefab;
    // 背包父物体
    public GameObject bagParent;
    // 背包提示框预制件
    public GameObject bagOnceTipPrefab;
    // 背包提示框组件
    public static GameObject bagOnceTip;

    // Start is called before the first frame update
    void Awake() {
        // 实例化bagOnceTip 组件
        bagOnceTip = GameObject.Instantiate(bagOnceTipPrefab, bagPanel.transform);
        if (bagOnceTip == null)
        {
            Debug.Log("bagOnceTip is null");
        }
        // 加载Sprite资源
        LoadAllSprites();
        // 克隆背包
        CloneBags();
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    // 加载所以Sprites资源
    void LoadAllSprites()
    {
        itemSprites = Resources.LoadAll<Sprite>("GUUI/Bags/Bags");
        Debug.Log("LoadAllSprites " +   itemSprites.Length);
    }


    void CloneBags()
    {
        // 克隆背包
        for (int i = 0; i < itemChineseNames.Length -1 ; i++)
        {
            // 初始化背包克隆体
            GameObject bagClone = Instantiate(bagPrefab, bagParent.transform);
            // 修改背包克隆体的名称
            bagClone.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = itemChineseNames[i];
            // 修改背包克隆体的图标
            bagClone.transform.Find("Icon").transform.GetComponent<UnityEngine.UI.Image>().sprite = itemSprites[i];
            // 修改背包克隆体的数量
            bagClone.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = "" + i;
            // 绑定事件组件
            bagClone.AddComponent<InventoryPointerController>();

        }
    }
}
