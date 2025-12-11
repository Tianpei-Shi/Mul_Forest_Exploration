using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class myMessage
{
	//类型
	public byte type;
	//命令
	public int command;
	//参数
	public object content;
	public myMessage(byte type, int command, params object[] content)
	{
		this.type = type;
		this.command = command;
		this.content = content;
	}
	//获取第几个参数
	public T GetContent<T>(int index)

	{
		object[] obj = (object[])content;
		return (T)(obj)[index];
	}

	[Serializable]
	public class Type
	{
		//类型
		public const byte Type_Account = 1; 
		public const byte Type_User = 2; 
		public const byte Type_Game = 3;

		//命令
		//注册账号(1账号 2密码）
		public const int Account_RegistC = 100;
		//1注册成功 0注册失败
		public const int Account_RegistS = 101;
		//登录账号(1账号 2密码）
		public const int Account_LoginC = 102;
		//返回ID登录成功 -1登录失败
		public const int Account_LoginS = 103;

		//选择角色 (模型id， 出生位置坐标）
		public const int User_SelectC = 104;
		//选择角色（用户id， 模型id， 位置float[]）
		public const int User_SelectS = 105;
		//创建角色（用户id, 模型id，位置float[]）
		public const int User_CreateS = 106;
		//移除
		public const int User_RemoveS = 107;

		//移动
		public const int Game_MoveC = 108;
		public const int Game_MoveS = 109;
		//攻击  (目标id)
		public const int Game_AttackC = 110;
		//攻击响应 攻击者id 目标id 被攻击者hp
		public const int Game_AttackS = 111;

	}
}
