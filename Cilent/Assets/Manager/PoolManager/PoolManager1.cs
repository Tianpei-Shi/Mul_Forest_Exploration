using UnityEngine;
using UnityEngine.Pool;

public class PoolManager1 : MonoBehaviour
{
    //使用unity的对象池
    private ObjectPool<GameObject> textPool;

    void Start()
    {
        //创建一个对象池
        textPool = new ObjectPool<GameObject>(
            () =>
            {
                return new GameObject();
            },
            obj =>
            {
                //从对象池中获取物体的操作
                obj.SetActive(true);
            },
            obj =>
            {
                //从对象池保存物品操作
                obj.SetActive(false);
            },
            obj =>
            {
                Destroy(obj);
            },
            true,100,1000
            );

        //获取一个对象
        GameObject go = textPool.Get();
        //回收一个对象
        textPool.Release(go);
    }

}
