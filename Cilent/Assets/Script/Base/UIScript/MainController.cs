using UnityEngine;

public class MainController : UIController
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //为按钮添加事件
        UIManager.Instance.GetControl("MainController", "Button").AddButtonClickEvent(ShowMemuController);
	}

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowMemuController()
    {
        //显示菜单界面
        UIManager.Instance.SetActive("MenuController", true);
		//关闭当前界面
        UIManager.Instance.SetActive("MainController", false);
	}
}
