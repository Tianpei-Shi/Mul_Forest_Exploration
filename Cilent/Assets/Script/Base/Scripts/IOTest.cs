using UnityEngine;

public class IOTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //鼠标的输入，点击,0左，1右，2滚轮
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("鼠标左键被按下");
        }
        //持续按下鼠标按键
        if (Input.GetMouseButton(0))
        {
            Debug.Log("鼠标左键被按下");
        }

        //键盘
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("空格键被按下");
        }

        //虚拟轴
        if (Input.GetAxis("Horizontal") > 0.0f)
        {
            Debug.Log("向右移动");
        }
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("按下空格");
        }
    }
}
