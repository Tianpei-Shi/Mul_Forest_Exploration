using TMPro;
using UnityEngine;

public class TipControl : MonoBehaviour
{
    public static TipControl Instance;
    public TextMeshProUGUI content;
	public void Awake()
	{
        if (Instance == null)
        {
            Instance = this;
        }
		else if (Instance != this)
		{
			// 如果已经存在实例，销毁当前对象
			Destroy(gameObject);
			return;
		}
		gameObject.SetActive(false);
	}
	void Start()
    {
        
    }

    public void ButtonClick()
    {
        gameObject.SetActive(false);
	}

    public void Show(string str)
    {
        content.text = str;
        gameObject.SetActive(true);
    }

		// Update is called once per frame
		void Update()
    {
        
    }
}
