using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//手动创建对象池
public class PoolStack
{
	//集合
	public Stack<UnityEngine.Object> stack = new Stack<Object>();
	//个数
	public int MaxCount = 100;

	//把游戏物体放入对象池
	public void Push(UnityEngine.Object obj)
	{
		if (stack.Count < MaxCount)
		{
			stack.Push(obj);
		}
		else
		{
			GameObject.Destroy(obj);
		}
	}
	//从对象池取出游戏物体
	public UnityEngine.Object Pop()
	{
		if (stack.Count > 0)
		{
			return stack.Pop();
		}
		else
		{
			return null;
		}
	}
	//清空对象池
	public void Clear()
	{
		foreach (UnityEngine.Object obj in stack)
		{
			GameObject.Destroy(obj);
		}
		stack.Clear();
	}
}

public class PoolManager
{
	private static PoolManager instance;

	public static PoolManager Instance
	{
		get
		{
			if(instance == null)
			{
				instance = new PoolManager();
			}
			return instance;
		}
	}

	//对象池集合
	Dictionary<string, PoolStack> poolDic = new Dictionary<string, PoolStack>();

	//从对象池取出对象，没有则创建一个
	public UnityEngine.Object Spawn(string poolName, UnityEngine.Object prefab)
	{
		if (!poolDic.ContainsKey(poolName))
		{
			poolDic.Add(poolName, new PoolStack());
		}
		UnityEngine.Object obj = poolDic[poolName].Pop();
		if (obj == null)
		{
			obj = GameObject.Instantiate(prefab);
		}
		return obj;
	}

	//清空对象池
	public void UnSpawn(string poolName)
	{
		if (!poolDic.ContainsKey(poolName))
		{
			poolDic[poolName].Clear();
			poolDic.Remove(poolName);
		}
	}
}
