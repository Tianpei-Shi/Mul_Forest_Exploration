using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private AudioSource bgmSource;
    private AudioSource seSource;

    void Awake()
    {
		if (Instance == null)
		{
			//创建跨场景的单例
			Instance = this;
			DontDestroyOnLoad(gameObject);
			//添加两个audioSource组件
			//背景音乐
			bgmSource = gameObject.AddComponent<AudioSource>();
			bgmSource.loop = true;
			//音效
			seSource = gameObject.AddComponent<AudioSource>();
			seSource.loop = false;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	//播放背景音乐
	public void PlayBgm(string name)
	{
		if (bgmSource.isPlaying)
		{
			return;
		}
		bgmSource.clip = Resources.Load<AudioClip>(name);
		bgmSource.Play();
	}

	//停止背景音乐
	public void StopBgm()
	{
		bgmSource.Stop();
	}

	//恢复
	public void ResumeBgm()
	{
		bgmSource.Play();
	}

	//停止
	public void PauseBgm()
	{
			bgmSource.Pause();
	}
	
	//修改播放声音
	public void SetBgmVolume(float volume)
	{
		bgmSource.volume = volume;

	}

	//播放音效
	public void PlaySe(string name, float volume = 1)
	{
		seSource.PlayOneShot(Resources.Load<AudioClip>(name), volume);
	}
}
