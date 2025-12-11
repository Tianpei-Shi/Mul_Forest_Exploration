using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsyncTest : MonoBehaviour
{
    AsyncOperation operation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(loadScene());
    }

    //创建协程方法
    IEnumerator loadScene()
    {
        operation = SceneManager.LoadSceneAsync(2);
        //加载完场景不要自动跳转
        operation.allowSceneActivation = false;
        yield return operation;
    }

    // Update is called once per frame

    void Update()
    {
        //输出进度
        Debug.Log(operation.progress);
        // timer += Time.deltaTime;
        // if (timer > 5)
        // {
        //     operation.allowSceneActivation = true;
        // }
    }
}
