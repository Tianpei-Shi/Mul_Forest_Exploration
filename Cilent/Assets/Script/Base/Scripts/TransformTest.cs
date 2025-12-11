using UnityEngine;

public class TransformTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //获取位置
        Debug.Log(transform.position);
        Debug.Log(transform.localPosition);
        //获取旋转
        Debug.Log(transform.rotation);
        Debug.Log(transform.localRotation);
        Debug.Log(transform.eulerAngles);
        Debug.Log(transform.localEulerAngles);
        //获取缩放
        Debug.Log(transform.localScale);
        //向量
        Debug.Log(transform.right);
        Debug.Log(transform.forward);
        Debug.Log(transform.up);

        //父子关系
        // Transform.parent.gameObject;
        // Transform.childCount;
        //解除与子物体的关系
        //transform.DetachChildren();
        //获取子物体
        // Transform tran = transform.Find("Child");
        // tran = transform.GetChild(0);
        //判断一个物体是不是另外一个物体的子物体
        // bool res = tran.IsChildOf(transform);
        // tran.SetParent(tran);
    }

    // Update is called once per frame
    void Update()
    {
        //看向000点
        //transform.LookAt(Vector3.zero);
        //旋转
        // transform.Rotate(Vector3.up, 90 * Time.deltaTime);
        //移动
        // transform.Translate(Vector3.forward * Time.deltaTime);
    }
}
