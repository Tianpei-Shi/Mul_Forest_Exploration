using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject go = this.gameObject;
        //游戏物体名称
        Debug.Log(go.name);
        //游戏物体的标签
        Debug.Log(go.tag);
        //游戏物体的层
        Debug.Log(go.layer);
        //获取激活状态
        Debug.Log(go.activeInHierarchy);
        Debug.Log(go.activeSelf);

        //获取父物体组件
        BoxCollider bs = this.GetComponentInParent<BoxCollider>();
        //获取子物体组件
        CapsuleCollider cc = this.GetComponentInChildren<CapsuleCollider>();

        //添加组件
        this.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
