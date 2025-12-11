using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class ItemData
{
	public string id;
	public string name;
	public string des;
	public string image;
}
public class ItemManager
{
	public static ItemManager instance;

	public static ItemManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new ItemManager();
			}
			return instance;
		}
	}

	//字典
	private Dictionary<string, ItemData> dic = new Dictionary<string, ItemData>();

	private ItemManager()
	{
		//解析xml
		XmlDocument doc = new XmlDocument();

		doc.Load(Application.dataPath + "Script/Advanced/141/newTest.xml");

		//根节点
		XmlElement rootEle = doc.LastChild as XmlElement;

		XmlElement itemsEle = rootEle.LastChild as XmlElement;

		//遍历items节点下的所有item节点
		foreach(XmlElement itemEle in itemsEle.ChildNodes)
		{
			//创建一个物品
			ItemData item = new ItemData();
			item.id = itemEle.GetAttribute("id");
			item.name = itemEle.ChildNodes[0].InnerText;
			item.des = itemEle.ChildNodes[1].InnerText;
			item.image = itemEle.ChildNodes[2].InnerText;
			//添加到字典
			dic.Add(item.id, item);
		}

	}

	//获取一个物品
	public ItemData GetItemById(string id)
	{
		if (dic.ContainsKey(id))
		{
			return dic[id];
		}
		return null;
	}
}