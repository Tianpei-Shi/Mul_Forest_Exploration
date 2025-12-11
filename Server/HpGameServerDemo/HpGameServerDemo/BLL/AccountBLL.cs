using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HpGameServerDemo
{
	public class AccountBLL : IMessageHandler
	{
		public void Server_OnClose(IntPtr connId)
		{
			DALManager.Instance.account.Logout(connId);
		}

		public void Server_OnReceive(IntPtr connId, myMessage message)
		{
			//收到账号的所有消息
			switch (message.command)
			{
				case myMessage.Type.Account_LoginC:
					Login(connId, message);
					break;
				case myMessage.Type.Account_RegistC:
					Register(connId, message);
					break;
			}
		}
		//注册账号(1账号 2密码）
		void Register(IntPtr connId, myMessage message)
		{
			int res = DALManager.Instance.account.Add(message.GetContent<string>(0), message.GetContent<string>(1));
			//给客户端返回结果
			Server.Send(connId, myMessage.Type.Type_Account, myMessage.Type.Account_RegistS, res);
		}

		//登录账号(1账号 2密码）
		void Login(IntPtr connId, myMessage message)
		{
			int res = DALManager.Instance.account.Login(connId, message.GetContent<string>(0), message.GetContent<string>(1));
			//给客户端返回结果
			Server.Send(connId, myMessage.Type.Type_Account, myMessage.Type.Account_LoginS, res);
			Console.WriteLine(res);
		}
	}
}
