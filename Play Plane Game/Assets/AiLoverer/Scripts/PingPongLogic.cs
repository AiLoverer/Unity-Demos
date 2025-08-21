using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongLogic : MonoBehaviour
{
    public float speed = 1.50f;
    // Start is called before the first frame update
    void Start()
    {
        this.InvokeRepeating("DoWork", 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0, -speed * Time.deltaTime, 0, Space.Self);
    }

    void DoWork(){
        //Debug.Log("DoWork ..." + Time.time);
        this.speed = 0 - this.speed;
    }
}
