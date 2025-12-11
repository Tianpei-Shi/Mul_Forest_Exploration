using System;
using UnityEngine;

public class MySingletonBase<T> : MonoBehaviour where T : MySingletonBase<T>
{
    public static T Instance;

	public virtual void Awake()
	{
		//判断当前实例是否存在
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
		}
		Instance = this as T;
		//不销毁对象
        DontDestroyOnLoad(gameObject);
	}
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
