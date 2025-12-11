using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HpGameServerDemo
{
	public class GameBLL : IMessageHandler
	{
		public void Server_OnClose(IntPtr connId)
		{
			
		}

		public void Server_OnReceive(IntPtr connId, myMessage message)
		{
			switch (message.command)
			{
				case myMessage.Type.Game_MoveC:
					Move(connId, message);
					break;
				case myMessage.Type.Game_AttackC:
					Attack(connId, message);
					break;
			}
		}

		private void Attack(IntPtr connId, myMessage message)
		{
			int targetId = message.GetContent<int>(0);
			//被攻击的用户
			UserModel targetUser = DALManager.Instance.user.GetUserModel(targetId);
			//攻击者
			UserModel user = DALManager.Instance.user.GetUserModel(connId);
			//伤害计算
			targetUser.HP -= user.Careerinfo.Attack;
			//发给所有客户端
			foreach(IntPtr ptr in DALManager.Instance.user.GetUserPtr())
			{
				Server.Send(ptr, myMessage.Type.Type_Game, myMessage.Type.Game_AttackS, user.ID, targetUser.ID, targetUser.HP);
			}
		}

		private void Move(IntPtr connId, myMessage message)
		{
			int userid = message.GetContent<int>(0);
			float[] targetPos = message.GetContent<float[]>(1);

			//通知所有客户端这个用户要移动到这个点
			foreach (IntPtr client in DALManager.Instance.user.GetUserPtr())
			{
				Server.Send(client, myMessage.Type.Type_Game, myMessage.Type.Game_MoveS, userid, targetPos);
			}
		}
	}
}
