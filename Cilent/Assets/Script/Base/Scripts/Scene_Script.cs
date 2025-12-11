using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Script : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        //名称
        Debug.Log(scene.name);
        //场景是否完成加载
        Debug.Log(scene.isLoaded);
        //场景路径
        Debug.Log(scene.path);
        //场景中的游戏物体
        GameObject[] gameObject = scene.GetRootGameObjects();
        Debug.Log(gameObject.Length);

        //切换场景
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {


    }
}
