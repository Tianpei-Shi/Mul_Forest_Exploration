using UnityEngine;
using HPSocket.Tcp;
using HPSocket;
using System;
using System.Text;
using NUnit.Framework;
using System.Collections.Generic;

public interface IMessage
{
    void Receive(myMessage msg);
}
public class Client : MonoBehaviour
{
    //单例
    public static Client Instance;
    //客户端连接对象
    TcpClient tcpClient = new TcpClient();
	//保存所有监听消息的对象
    public List<IMessage> messageLisetener = new List<IMessage>();
    //消息队列
    Queue<myMessage> messageQueue = new Queue<myMessage>();

	void Awake()
    {
		Instance = this;
        //让当前游戏物体不被销毁
        DontDestroyOnLoad(gameObject);
        //设置服务器的地址和端口
        tcpClient.Address = "127.0.0.1";
        tcpClient.Port = Convert.ToUInt16(5566);
        //接受服务端发来的消息
        tcpClient.OnReceive += TcpClient_OnReceive;
        tcpClient.Connect();
	}

	//添加监听
    public static void AddListener(IMessage msgListener)
    {
        if (!Instance.messageLisetener.Contains(msgListener))
        {
            Instance.messageLisetener.Add(msgListener);
        }
	}
	//移除监听
    public static void RemoveListener(IMessage msgListener)
    {
        if (Instance.messageLisetener.Contains(msgListener))
        {
            Instance.messageLisetener.Remove(msgListener);
        }
	}

    //发送消息
    public static void Send(myMessage msg)
    {
        Instance.tcpClient.Send(myMessageTool.ToByte(msg), myMessageTool.ToByte(msg).Length);
    }

	private HandleResult TcpClient_OnReceive(IClient sender, byte[] data)
    {
        ////测试接收到服务端发来的消息
        //string msg = Encoding.UTF8.GetString(data);
        //Debug.Log(msg);

        //二进制转成消息
        myMessage msg = myMessageTool.ToObject(data) as myMessage;
        messageQueue.Enqueue(msg);
		return HandleResult.Ok;
    }

    void Update()
    {
		//if (Input.GetMouseButton(0))
		//{
		//    byte[] data = Encoding.UTF8.GetBytes("Hello,我是客户端。");
		//    tcpClient.Send(data, data.Length);
		//}

		//从队列中取出消息
		if (messageQueue.Count > 0)
        {
            myMessage msg = messageQueue.Dequeue();
            //把消息传递给所有监听者
            foreach(IMessage msgListener in messageLisetener)
            {
                msgListener.Receive(msg);
			}
		}
    }
}
