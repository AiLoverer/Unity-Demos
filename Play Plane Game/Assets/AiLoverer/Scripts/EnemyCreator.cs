using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    public GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateEnemy", 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 创建敌人
    void CreateEnemy()
    {
        // 随机生成一个位置
        float x = Random.Range(-30, 30);
        GameObject enemy = Instantiate(enemyPrefab, null);
        enemy.transform.position = this.transform.position;
        enemy.transform.Translate(x, 0, 0, Space.Self);
    }
}
