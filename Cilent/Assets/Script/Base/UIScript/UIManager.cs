using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    //管理所有的UI界面
    public Dictionary<string, UIController> ControllerDic = new Dictionary<string, UIController>();
	private void Awake()
	{
		Instance = this;
	}
	void Start()
    {
        
    }

    void Update()
    {
        
    }

    //设置的激活或者取消页面
    public void SetActive(string controllerName, bool active)
    {
        //动态加载
        //var go = Instantiate(Resources.Load<GameObject>(controllerName), transform);

        //查找当前页面的名称
        transform.Find(controllerName).gameObject.SetActive(active);
	}

    //获取页面中的控件
    public UIControl GetControl(string controllerName, string controlName)
    {
        //查看1是否存在这个页面
        if (ControllerDic.ContainsKey(controllerName))
        {
            //查看这个页面是否包含这个控件
            if (ControllerDic[controllerName].ControlDic.ContainsKey(controlName))
            {
                return ControllerDic[controllerName].ControlDic[controlName];
            }
        }
		return null;
	}
}
