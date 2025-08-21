using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    // 前后移动移动速度Y
    public float moveSpeedY = 0.0f;
    // 横向移动速度X
    float moveSpeedX = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SnakeMove", 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        float dy = moveSpeedY * Time.deltaTime;
        float dx = moveSpeedX * Time.deltaTime;
        transform.Translate(dx, -dy, 0, Space.Self);

        // 检测是否需要消失
        CheckDisappear();
    }

    void SnakeMove()
    {
        float[] options = {-10, -5, 5, 10};
        int index = Random.Range(0, options.Length);
        moveSpeedX = options[index];
    }

    // 检测是否需要消失
    void CheckDisappear() {
        // 检测是否超出屏幕
        if (transform.position.x > 30 ) {
            Destroy(gameObject);
        }
    }
}
