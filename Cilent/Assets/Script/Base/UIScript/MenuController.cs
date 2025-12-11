using UnityEngine;

public class MenuController : UIController
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		UIManager.Instance.GetControl("MenuController", "Info").AddButtonClickEvent(showInfoController);
		UIManager.Instance.GetControl("MenuController", "Cancel").AddButtonClickEvent(showMainController);
	}

    // Update is called once per frame
    void Update()
    {
        
    }

    void showInfoController()
    {
               //显示信息界面
        UIManager.Instance.SetActive("InfoController", true);
		//关闭当前界面
        UIManager.Instance.SetActive("MenuController", false);
	}
	void showMainController()
	{
		//显示信息界面
		UIManager.Instance.SetActive("MainController", true);
		//关闭当前界面
		UIManager.Instance.SetActive("MenuController", false);
	}

}
