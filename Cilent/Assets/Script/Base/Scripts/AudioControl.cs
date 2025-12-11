using UnityEngine;

public class AudioControl : MonoBehaviour
{
    private AudioSource player;

    public AudioClip clip;
	void Start()
    {
        player = GetComponent<AudioSource>();
	}

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //左键点击时播放音效
            if (player.isPlaying)
            {
                player.Stop();
            }else
            {
                player.Play();
                player.volume = 0.3f;
			}

            //音效
            if (Input.GetMouseButtonDown(1))
            {
				AudioClip clip2 = Resources.Load<AudioClip>("");
				player.PlayOneShot(clip2);
			}
		}
	}
}
