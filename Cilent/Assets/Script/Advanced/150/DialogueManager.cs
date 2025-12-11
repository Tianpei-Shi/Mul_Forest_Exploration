using UnityEngine;
using UnityEngine.UI;

public class Dialogue
{
	public string name;
	public string text;
}

public class DialogueManager : MonoBehaviour
{
	public static DialogueManager Instance;

	//关联控件
	public Text Name;
	public Text Content;

	private Dialogue[] dialogues;
	private int index = 0;

	void Awake()
	{
		Instance = this;
		gameObject.SetActive(false);
	}

	//开始对话
	public void StartDialogue(Dialogue[] dialogues)
	{
		gameObject.SetActive(true);
		this.dialogues = dialogues;
		index = 0;
		Show();
	}

	void Show()
	{
		//如果对话结束
		if (index >= dialogues.Length)
		{
			gameObject.SetActive(false);
			return;
		}
		//拿出当前对话
		Dialogue dialogue = dialogues[index++];
		Name.text = dialogue.name;	
		Content.text = dialogue.text;
	}
}
