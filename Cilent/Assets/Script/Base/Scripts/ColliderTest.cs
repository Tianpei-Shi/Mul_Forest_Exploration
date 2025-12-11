using UnityEngine;

public class ColliderTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    //碰撞调用一次
	private void OnCollisionEnter(Collision collision)
	{
		Debug.Log("碰撞开始: " + collision.gameObject.name);
	}
	//碰撞持续调用
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("碰撞持续: " + collision.gameObject.name);
	}
    //结束碰撞
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("碰撞结束: " + collision.gameObject.name);
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
