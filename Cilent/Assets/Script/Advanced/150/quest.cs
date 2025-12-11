using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Quest
{
	public string title;
	public string name;
	public string des;
	public string target;
	public int targetCount;
	public string money;

	//当前完成个数
	public int currentCount;
	//是否完成
	public bool hasComplete;
}

public class quest : MonoBehaviour
{
	public static quest instance;
	//所有任务
	public Dictionary<string, Quest> questDict = new Dictionary<string, Quest>();
	//接受的任务
	public List<string> MyQuest = new List<string>();
	void Awake()
    {
        instance = this;
	}

	void LoadXML()
	{
		//解析xml
		XmlDocument doc = new XmlDocument();
		doc.Load(Application.dataPath + "/Script/Advanced/151/quest.xml");
		XmlElement rootEle = doc.LastChild as XmlElement;
		foreach (XmlElement questEle in rootEle.ChildNodes)
		{
			Quest newQuest = new Quest();
			newQuest.title = questEle.ChildNodes[0].InnerText;
			newQuest.name = questEle.ChildNodes[1].InnerText;
			newQuest.des = questEle.ChildNodes[2].InnerText;
			newQuest.target = questEle.ChildNodes[3].FirstChild.InnerText;
			newQuest.targetCount = int.Parse(questEle.ChildNodes[3].LastChild.InnerText);
			newQuest.money = questEle.ChildNodes[4].FirstChild.InnerText;
			questDict.Add(newQuest.title, newQuest);
		}

	}

	//是否有该任务
	public bool hasQuest(string id)
	{
		if (MyQuest.Contains(id))
			return true;
		return false;
	}

	//接受任务
	public bool addQuest(string id)
	{
		if (hasQuest(id) || questDict[id].hasComplete)
		{
			return false;
		}
		//添加任务
		MyQuest.Add(id);
		return true;
	}

	//完成任务
	public bool endQuest(string id)
	{
		//如果没接收任务，或者任务已经完成，任务没完成
		if (!hasQuest(id) || questDict[id].hasComplete || questDict[id].currentCount < questDict[id].targetCount)
			return false;
		//任务完成
		questDict[id].hasComplete = true;
		return true;
	}


	void Update()
	{

	}
}
