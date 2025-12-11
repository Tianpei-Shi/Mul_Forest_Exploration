using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class LoginControl : MonoBehaviour, IMessage
{
    public TMP_InputField nameField;
    public TMP_InputField passwordField;

	public void Awake()
	{
		      gameObject.SetActive(false);
    }
	void Start()
    {
        //注册消息监听
        Client.AddListener(this);
	}
	//发起登录请求
	public void Log()
    {
		if (nameField.text.Length <= 3 || passwordField.text.Length <= 3)
		{
			Debug.LogWarning("用户名和密码长度必须大于3位！");
			return;
		}

		myMessage message = new myMessage(myMessage.Type.Type_Account, myMessage.Type.Account_LoginC, nameField.text, passwordField.text);
		Client.Send(message);
	}
    //发起注册请求
    public void Reg()
    {
        if (nameField.text.Length <= 3 || passwordField.text.Length <= 3)
        {
            Debug.LogWarning("用户名和密码长度必须大于3位！");
            return;
        }

        myMessage message = new myMessage(myMessage.Type.Type_Account, myMessage.Type.Account_RegistC, nameField.text, passwordField.text);
        Client.Send(message);
    }

	// Update is called once per frame
	void Update()
    {
        
    }

    //Start页面点击按钮显示当前页面
    public void show()
    {
        gameObject.SetActive(true);
	}

	public void Receive(myMessage msg)
	{
		//如果消息类型不是账号类型，直接返回
		if (msg.type != myMessage.Type.Type_Account)
        {
            return;
        }
		//如果接收到服务器发来的注册相应
        if(msg.command == myMessage.Type.Account_RegistS)
        {
            int res = msg.GetContent<int>(0);
            if(res == 1)
            {
                TipControl.Instance.Show("恭喜，注册成功");
				Debug.Log("注册成功");
			}
            else
            {
                TipControl.Instance.Show("注册失败，用户名已存在");
				Debug.Log("注册失败");
			}
		}
		//如果接收到服务发来的登录响应
        if(msg.command == myMessage.Type.Account_LoginS)
        {
            int userID = msg.GetContent<int>(0);
            if(userID > 0)
            {
                Debug.Log("登录成功，用户ID为：" + userID);
				//登录成功，隐藏当前登录界面和Star界面
                Transform Canvas = GetComponentInParent<Canvas>().transform;
                Transform Start = Canvas.Find("Start");
                Transform Select = Canvas.Find("Select");
				if (Start != null)
                {
                    Start.gameObject.SetActive(false);
                    gameObject.SetActive(false);
                    Select.gameObject.SetActive(true);
				}
			}
			else
            {
                Debug.Log("登录失败，用户名或密码错误");
                TipControl.Instance.Show("登录失败，用户名或密码错误");
			}
		}
	}
}
