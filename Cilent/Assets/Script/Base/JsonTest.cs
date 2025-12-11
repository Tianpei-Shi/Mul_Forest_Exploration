using Defective.JSON;
using UnityEditor.ShaderGraph.Serialization;
using UnityEngine;


public class JsonTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string json = getJson();
        parseJson(json);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    string getJson()
    {
        //最外层是个对象
        JSONObject root = JSONObject.emptyObject;
        //创建数组结构
        JSONObject items = JSONObject.emptyArray;
        //赋值{"items":[]}
        root["items"] = items;
        //创建木剑
        JSONObject item1 = JSONObject.emptyObject;
        item1["name"] = JSONObject.CreateStringObject("木剑");
        item1["attack"] = JSONObject.Create(10);
        //创建铁剑
        JSONObject item2 = JSONObject.emptyObject;
		item2["name"] = JSONObject.CreateStringObject("铁剑");
        item2["attack"] = JSONObject.Create(15);
		//把木剑和铁剑放到数组中
        items.Add(item1);
        items.Add(item2);
        //把对象转换成字符串
        string json = root.ToString();
        Debug.Log(json);
        return json;
	}

    //解析JSON
    void parseJson(string json)
    {
        //把字符串转换成JSON对象
        JSONObject root = JSONObject.Create(json);
        //取出items数组
        JSONObject items = root["items"];
        //遍历数组
        foreach(JSONObject item in items)
        {
            //拿到物品名称
            string name = item["name"].stringValue;
			//拿到物品攻击力
            int attack = item["attack"].intValue;
            Debug.Log(name);
            Debug.Log(attack);
		}
	}
}
