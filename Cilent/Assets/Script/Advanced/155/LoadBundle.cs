using UnityEngine;

public class LoadBundle : MonoBehaviour
{
    void Start()
    {
        loadmat();
        loadBundle();
    }

    void loadmat()
    {
        string path = Application.dataPath + "/AssetBundle/AssetBundle";
        AssetBundle ab = AssetBundle.LoadFromFile(path);
        //获取manifest信息文件
        AssetBundleManifest mf = ab.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
        //获取cube.ab包的所有依赖
        string[] strs = mf.GetAllDependencies("cube.ab");
        //遍历加载包的所有依赖
        foreach(string str in strs)
        {
            string tmpPath = Application.dataPath + "/str";
            AssetBundle.LoadFromFile(tmpPath);
        }
    }

    void loadBundle()
    {
        //包路径
        string path = Application.dataPath + "/AssetBundle/cube.ab";
        //加载包
        AssetBundle ab = AssetBundle.LoadFromFile(path);
        //通过名称获取包中的资源
        GameObject Cube = ab.LoadAsset<GameObject>(path);
        //实例化
        Instantiate(Cube);
    }
}
