using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public Dictionary<string, UIControl> ControlDic = new Dictionary<string, UIControl>();

	private void Awake()
	{
		//让页面加载到UI单例管理中
        UIManager.Instance.ControllerDic.Add(transform.name, this);

        //给当前页面的所有控件添加UIControl脚本
        foreach (Transform tran in transform)
        {
            //如果这个子物体身上没有UIControl脚本
            if (tran.gameObject.GetComponent<UIControl>() == null)
            {
                tran.gameObject.AddComponent<UIControl>();
            }
        }
	}
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
