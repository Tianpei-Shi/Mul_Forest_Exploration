using System.Xml;
using UnityEngine;

public class XML : MonoBehaviour
{
    void Start()
    {
        CreateXML();

	}

    //创建一个XML文件
    void CreateXML()
    {
        //创建xml文档类
        XmlDocument doc = new XmlDocument();
        //创建文档声明
        XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "utf-8", "");
		//添加到文档中
        doc.AppendChild(dec);
        //创建根节点
        XmlElement rootElement = doc.CreateElement("root");
        //添加到文档中
        doc.AppendChild(rootElement);
        //创建item节点
        XmlElement itemElement = doc.CreateElement("items");
		//添加到根节点中
        rootElement.AppendChild(itemElement);
        //创建三个item节点
        string[] names = new string[] { "血瓶", "木剑", "飞镖" };
        string[] des = new string[] {"这是一个小血瓶", "这是一把木剑", "这是一把飞镖" };
        //循环创建item节点
        for(int i = 0; i < 3; i++)
        {
            //创建item节点
            XmlElement itemEle = doc.CreateElement("item");
            itemElement.AppendChild(itemEle);

			//创建name节点
			XmlElement nameEle = doc.CreateElement("name");
            nameEle.InnerText = names[i];
			itemEle.AppendChild(nameEle);  // 修改：添加到item节点下

			//创建des节点
			XmlElement desEle = doc.CreateElement("des");
            desEle.InnerText = des[i];
			itemEle.AppendChild(desEle);   // 修改：添加到item节点下

            //添加属性
            //itemEle.SetAttribute("id", (i+1).ToString());
            XmlAttribute attribute = doc.CreateAttribute("id");
            attribute.Value = (i + 1).ToString();
            itemEle.Attributes.Append(attribute);
		}
        //保存成xml文件
		doc.Save(Application.dataPath + "/Script/Advanced/141/newTest.xml");
	}

    //解析XML文件
    void ParseXML()
    {
        //xml文档类
        XmlDocument doc = new XmlDocument();
		//读取一个xml文件
        doc.Load(Application.dataPath + "newTest.xml");
        //获取根节点
        XmlElement root = doc.LastChild as XmlElement;
		//获取items节点
        XmlElement itemsEle = root.FirstChild as XmlElement;
        //遍历获取item节点
        foreach(XmlElement itemEle in itemsEle.ChildNodes)
        {
            //获取id
            string id = itemEle.GetAttribute("id");
			//获取name
            //string name = itemEle["name"].InnerText;
            string name = itemEle.ChildNodes[0].InnerText;
            //des
            string des = itemEle.ChildNodes[1].InnerText;
			Debug.Log("id: " + id + " name: " + name + " des: " + des);
		}
	}

    void ParseXML2()
    {
        //xml文档类
        XmlDocument doc = new XmlDocument();
        //读取一个xml文件
        doc.Load(Application.dataPath + "newTest.xml");
		//使用XPath选择节点
		/*
		 语法
         /root/items/item/name 选择所有name节点
        //root//name 选择所有name节点
        /root/items/item[@id='1']/name 选择item节点中id属性值为1的name节点
        /root/items/item[1]/name 选择第一个item节点中的name节点
        /root/items/item[last()]/name 选择最后一个item节点中的name节点
        /root/items/item[position()<3]/name 选择前两个item节点中的name节点

        */
		XmlNodeList list = doc.SelectNodes("/root/items/item/name");
        foreach(XmlElement nameEle in list)
        {
            Debug.Log("name: " + nameEle.InnerText);
		} 
	}
}
