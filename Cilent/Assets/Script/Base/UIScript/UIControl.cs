using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Events;
public class UIControl : MonoBehaviour
{
    //属于的页面
    public UIController controller;
    private void Awake()
    {
        //向上查找父物体的UIController组件
        if (transform.parent != null)
        {
            controller = transform.GetComponentInParent<UIController>();
            //判断是否有脚本
			if (controller != null)
			{
				//有脚本， 找到了父页面
				controller.ControlDic.Add(transform.name, this);
			}
		}


    }


    void Start()
    {

    }


    void Update()
    {

    }

    //封装好多好用的UI控件方法
    //尝试实现修改图片
    public void ChangeImage(Sprite sprite)
    {
        if (GetComponent<Image>() != null)
        {
            GetComponent<Image>().sprite = sprite;
        }
    }

    //修改文本
    public void ChangeText(string text)
    {
        if (GetComponent<Text>() != null)
        {
            GetComponent<Text>().text = text;
        }
    }

    //修改按钮的点击事件
    public void AddButtonClickEvent(UnityAction action)
    {
        if (GetComponent<Button>() != null)
        {
            GetComponent<Button>().onClick.AddListener(action);
        }
    }
}
