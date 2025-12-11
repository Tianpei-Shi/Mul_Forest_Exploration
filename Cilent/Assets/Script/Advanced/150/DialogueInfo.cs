using UnityEngine;

public class DialogueInfo : MonoBehaviour
{

    //对话
    public Dialogue[] dialogue;
    private GameObject player;

	void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
	}

    void Update()
    {
        if(Vector3.Distance(player.transform.position, transform.position) < 3f)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
				//触发对话
                DialogueManager.Instance.StartDialogue(dialogue);
			}
		}
	}
}
