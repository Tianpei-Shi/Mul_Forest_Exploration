using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class MessageCenter : MySingletonBase<MessageCenter>
{
	public List<ManagerBase> Managers = new List<ManagerBase>();

	//注册管理类
	public void Register(ManagerBase manager)
	{
		if (!Managers.Contains(manager))
		{
			Managers.Add(manager);
		}
	}

	//发消息
	public void SendMessage(iMessage msg)
	{
		foreach (var manager in Managers)
		{
			manager.ReceiveMessage(msg);
		}
	}
}
