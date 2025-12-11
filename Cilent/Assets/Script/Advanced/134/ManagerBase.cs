using System.Collections.Generic;
using UnityEngine;

public abstract class  ManagerBase : MySingletonBase<ManagerBase>
{
	//管理功能模块
	public static List<MonoBase> Monos = new List<MonoBase>();

	//注册功能模块
	public static void Register(MonoBase mono)
	{
		if (!Monos.Contains(mono))
		{
			Monos.Add(mono);
		}
	}
	//接受消息
	public virtual void ReceiveMessage(iMessage msg)
	{
		//如果消息类型不匹配
	}

	//设置当前管理器接受消息
	public abstract void GetmessageType(iMessage msg);
}
