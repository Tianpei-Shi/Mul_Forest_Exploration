using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using HPSocket;
using HPSocket.Tcp;


namespace HpGameServerDemo
{
	public class Server
	{
		//创建一个接受消息用的socket服务端
		public static TcpServer server = new TcpServer();
		//构造
		public Server()
		{
			//ip地址
			server.Address = "127.0.0.1";
			//端口
			server.Port = Convert.ToUInt16(5566);
			//接收到客户端连接
			server.OnAccept += Server_OnAccept;
			//客户端断开连接
			server.OnClose += Server_OnClose;
			//接收到客户端发送的数据
			server.OnReceive += Server_OnReceive;
			//启动
			server.Start();
		}

		private HandleResult Server_OnReceive(IServer sender, IntPtr connId, byte[] data)
		{
			////测试打印接收到的消息
			//string msg = Encoding.UTF8.GetString(data);
			//Console.WriteLine("收到消息:" + msg);
			////回复客户端
			//byte[] sendData = Encoding.UTF8.GetBytes("服务器已收到消息:" + msg);
			////测试给客户端回消息
			//server.Send(connId, sendData,sendData.Length);

			//把二进制转成myMessage对象
			myMessage message = myMessageTool.ToObject(data);

			switch (message.type)
			{
				case myMessage.Type.Type_Account:
					//分发到帐号模块
					BLLManager.Instance.account.Server_OnReceive(connId, message);
					break;
				case myMessage.Type.Type_User:
					//分发到用户模块
					BLLManager.Instance.user.Server_OnReceive(connId, message);
					break;
				case myMessage.Type.Type_Game:
					//分发到游戏模块
					BLLManager.Instance.game.Server_OnReceive(connId, message);
					break;
			}
			return HandleResult.Ok;
		}

		//发送消息给客户端
		public static void Send(IntPtr ptr, byte type, int command, params object[] obj)
		{
			//创建一个消息对象
			myMessage msg = new myMessage(type, command, obj);
			//转成二进制
			byte[] data = myMessageTool.ToByte(msg);
			//发送
			server.Send(ptr, data, data.Length);
		}

		private HandleResult Server_OnClose(IServer sender, IntPtr connId, SocketOperation socketOperation, int errorCode)
		{
			//分发关闭消息
			BLLManager.Instance.account.Server_OnClose(connId);
			BLLManager.Instance.user.Server_OnClose(connId);
			BLLManager.Instance.game.Server_OnClose(connId);
			return HandleResult.Ok;
		}

		private HandleResult Server_OnAccept(IServer sender, IntPtr connId, IntPtr client)
		{
			Console.WriteLine("有客户端成功连接");
			return HandleResult.Ok;
		}
	}
}
