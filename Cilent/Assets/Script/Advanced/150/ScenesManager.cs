using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager
{
	private static ScenesManager instance;

	public static ScenesManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new ScenesManager();
			}
			return instance;
		}
	}

	//异步加载
	public void LoadSceneAsync(string sceneName, LoadSceneMode mode = LoadSceneMode.Single, Action finishAction = null)
	{
		SceneManager.LoadSceneAsync(sceneName, mode).completed += (obj) =>
		{
			//场景加载完成后回调
			finishAction?.Invoke();
		};
	}

	public void LoadSceneAsync(int sceneIndex, LoadSceneMode mode = LoadSceneMode.Single, Action finishAction = null)
	{
		SceneManager.LoadSceneAsync(sceneIndex, mode).completed += (obj) =>
		{
			//场景加载完成后回调
			finishAction?.Invoke();
		};
	}

	//加载上一个场景
	public void LoadPrevScenesAsync(LoadSceneMode mode = LoadSceneMode.Single, Action<bool> finishAction = null)
	{
		//得到当前场景
		Scene scene = SceneManager.GetActiveScene();
		//如果上一个场景小于0
		if (scene.buildIndex - 1 < 0)
		{
			finishAction?.Invoke(false);
			return;
		}
		//加载前一个场景
		LoadSceneAsync(scene.buildIndex - 1, mode, () =>
		{
			finishAction?.Invoke(true);
		});
	}
}
