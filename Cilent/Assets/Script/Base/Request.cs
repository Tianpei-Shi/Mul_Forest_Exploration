using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class Request : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(request());
    }

	//进行网络请求
    IEnumerator request()
    {
        //创建一个请求
        var request = UnityWebRequest.Get("https://baudu.com");
        yield return request.SendWebRequest();
		//代码执行到这里，说明请求已经结束，拿到相应的内容
	}
}
