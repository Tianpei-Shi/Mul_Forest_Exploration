using UnityEngine;

public class TouchTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //开启多点触摸
        Input.multiTouchEnabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        //判断单点触摸
        if (Input.touchCount == 1)
        {
            Touch touch = Input.touches[0];
            Debug.Log("触摸点坐标：" + touch.position);
            Debug.Log(touch.position);
            
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    Debug.Log("触摸开始");
                    break;
                case TouchPhase.Moved:
                    Debug.Log("触摸移动");
                    break;
                case TouchPhase.Stationary:
                    Debug.Log("触摸停滞");
                    break;
                case TouchPhase.Ended:
                    Debug.Log("触摸结束");
                    break;
                case TouchPhase.Canceled:
                    Debug.Log("触摸取消");
                    break;
            }
        }
        

        //判断多见触摸
        if (Input.touchCount == 2)
        {
            Touch touch1 = Input.touches[0];
            Touch touch2 = Input.touches[1];
        }
    }
}
