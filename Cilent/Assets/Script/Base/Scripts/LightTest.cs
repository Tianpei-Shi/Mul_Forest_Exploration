using UnityEngine;

public class LightTest : MonoBehaviour
{
     private Light light1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //获取灯光组件
        light1 = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        //鼠标左键开启灯光
        if (Input.GetMouseButtonDown(0))
        {
            light1.enabled = true;
        }
        //鼠标右键关闭灯光
        if (Input.GetMouseButtonDown(1))
        {
            light1.enabled = false;
        }
        //获取鼠标滚轮数值
        float value = Input.GetAxis("Mouse ScrollWheel");
        //修改灯光强度
        light1.intensity += value;
        //修改灯光的范围
        light1.range += value;
	}
}
