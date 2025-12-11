using UnityEngine;

public class iMessage
{
	//类型
	public byte Type;
	//命令
	public string Command;
	//参数
	public object[] Content;

	public iMessage(byte type, string command, params object[] content)
	{
		Type = type;
		Command = command;
		Content = content;
	}
	//消息类型
	public class iMessageType
	{
		//系统消息
		public const byte System = 0;
		//用户消息
		public const byte User = 1;
		//ui
		public const byte Type_UI = 2;

		//声音命令
		public static int Audio_PlaySound = 100;
	}
}
