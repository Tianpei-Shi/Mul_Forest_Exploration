using System;
using UnityEngine;

public class TimeTest : MonoBehaviour


{
    float timer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //游戏从开始到现在所用的时间
        // Debug.Log(Time.time);

        //时间缩放数值
        // Time.timeScale = 0.5f;
        Debug.Log(Time.timeScale);

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 5)
        {
            Debug.Log("5秒过去了");
            timer = 0;
        }
    }
}
