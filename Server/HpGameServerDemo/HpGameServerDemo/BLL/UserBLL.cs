using System;

namespace HpGameServerDemo
{
	public class UserBLL : IMessageHandler
	{
		public void Server_OnClose(IntPtr connId)
		{
			//用户下线
			//得到下线用户
			UserModel model = DALManager.Instance.user.GetUserModel(connId);
			//移除角色
			DALManager.Instance.user.RemoveUser(connId);
			foreach (IntPtr client in DALManager.Instance.user.GetUserPtr())
			{
				Server.Send(client, myMessage.Type.Type_User, myMessage.Type.User_RemoveS, model.ID);
			}
		}

		public void Server_OnReceive(IntPtr connId, myMessage message)
		{
			switch (message.command)
			{
				case myMessage.Type.User_SelectC:
					//进入游戏要干什么
					//创建其他玩家
					CreateOtherUser(connId, message);
					//创建自己
					CreateUser(connId, message);
					//其他玩家创建自己
					CreateUserByOther(connId, message);

					break;
			}
		}
		//其他玩家创建自己
		private void CreateUserByOther(IntPtr connId, myMessage message)
		{
			//获取自己
			UserModel model = DALManager.Instance.user.GetUserModel(connId);
			//遍历除了自己的客户端发送创建的消息
			foreach (IntPtr client in DALManager.Instance.user.GetUserPtr())
			{
				if (client == connId)
				{
					continue;
				}
				Server.Send(client, myMessage.Type.Type_User, myMessage.Type.User_CreateS, model.ID, model.Careerinfo.ModelID, model.points);
			}

		}
		//创建自己
		private void CreateUser(IntPtr connId, myMessage message)
		{
			int modelid = message.GetContent<int>(0);
			//创建玩家模型
			int userid = DALManager.Instance.user.AddUser(connId, modelid);
			//获取刚创建的自己的模型
			UserModel model = DALManager.Instance.user.GetUserModel(userid);
			//给模型初始化位置坐标
			model.points = message.GetContent<float[]>(1);
			Server.Send(connId, myMessage.Type.Type_User, myMessage.Type.User_SelectS, userid, modelid, model.points); ;
		}
		//创建其他玩家
		private void CreateOtherUser(IntPtr connId, myMessage message)
		{
			//遍历所有玩家并创建
			foreach (UserModel model in DALManager.Instance.user.GetUserModels())
			{
				//创建这些角色
				Server.Send(connId, myMessage.Type.Type_User, myMessage.Type.User_CreateS, model.ID, model.Careerinfo.ModelID, model.points);
			}
		}
	}
}
