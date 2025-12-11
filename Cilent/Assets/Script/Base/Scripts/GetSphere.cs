using UnityEngine;

public class GetSphere : MonoBehaviour
{
    public GameObject go;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //真真激活状态
        Debug.Log(go.activeInHierarchy);
        //自己激活的状态
        Debug.Log(go.activeSelf);
        //设置激活状态
        go.SetActive(false);
        //获取组件
        Transform trans = this.transform;
        //获取其他组件
        BoxCollider box = this.GetComponent<BoxCollider>();
        box.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
