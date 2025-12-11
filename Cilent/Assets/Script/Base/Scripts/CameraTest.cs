using UnityEngine;

public class CameraTest : MonoBehaviour
{
    //相机1
    public Camera camera1;
	//相机2
    public Camera camera2;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //获取玩家和第一个相机的距离
        float distance1 = Vector3.Distance(camera1.transform.position, transform.position);
        //获取玩家和第二个相机的距离
        float distance2 = Vector3.Distance(camera2.transform.position, transform.position);
        //判断距离
        if(distance1 < distance2)
        {
            camera1.depth = 1;
            camera2.depth = 0;
		}else
        {
            camera1.depth = 0;
            camera2.depth = 1;
        }

	}
}
