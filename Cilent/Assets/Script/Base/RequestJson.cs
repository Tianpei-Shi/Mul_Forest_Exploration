using Defective.JSON;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class RequestJson : MonoBehaviour
{
    private TextMeshProUGUI text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();

        //开始请求
        StartCoroutine(request());

	}

    IEnumerator request()
    {
        var request = UnityWebRequest.Get("https://restapi.amap.com/v3/weather/weatherInfo?key=ab5f3cfc673900c281c2d9ddd9332703&city=310000&extensions=base&output=JSON");
        yield return request.SendWebRequest();
        //判断相应结果
        if (request.result == UnityWebRequest.Result.Success)
        {
            jsonParse(request.downloadHandler.text);
		}
    }
    void jsonParse(string json)
    {
        //开始解析天气的json
        JSONObject root = JSONObject.Create(json);
        JSONObject lives = root["lives"];
        JSONObject data = lives[0];
		string city = data["city"].stringValue;
		string weather = data["weather"].stringValue;
		string temperature = data["temperature"].stringValue;
		string reporttime = data["reporttime"].stringValue;

        string str = "日期:" + reporttime + "\n城市:" + city + "\n天气:" + weather + "\n温度:" + temperature;
        Debug.Log(str);
		text.text = str;
	}
}
