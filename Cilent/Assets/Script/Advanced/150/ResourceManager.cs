using System;
using UnityEngine;

public class ResourceManager
{
	private static ResourceManager instance;
	public static ResourceManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new ResourceManager();
			}
			return instance;
		}
	}

	//同步加载
	public T Load<T>(string path) where T : UnityEngine.Object
	{
		return Resources.Load<T>(path);
	}

	//异步加载
	public void LoadAsync<T>(string path, Action<T> finishAction) where T : UnityEngine.Object
	{
		Resources.LoadAsync<T>(path).completed += (obj) =>
		{
			ResourceRequest request = (ResourceRequest)obj;
			finishAction?.Invoke(request.asset as T);
		};
	}
}