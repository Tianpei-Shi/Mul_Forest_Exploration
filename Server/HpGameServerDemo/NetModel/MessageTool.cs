using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class myMessageTool
{
	//对象转二进制
	public static byte[] ToByte(object obj)
	{
		if (obj == null)
		{
			return null;
		}
		try
		{
			MemoryStream ms = new MemoryStream();
			new BinaryFormatter().Serialize(ms, obj);
			byte[] data = new byte[ms.Length];
			Buffer.BlockCopy(ms.GetBuffer(), 0, data, 0, (int)ms.Length);
			ms.Close();
			return data;
		}
		catch (Exception ex)
		{
			Console.WriteLine("ObjectToBytes error:" + ex.Message);
			return null;
		}
	}

	//二进制转对象
	public static myMessage ToObject(byte[] data)
	{
		if (data == null)
		{
			return null;
		}
		try
		{
			MemoryStream ms = new MemoryStream(data);
			object obj = new BinaryFormatter().Deserialize(ms);
			ms.Close();
			return obj as myMessage;
		}
		catch (Exception ex)
		{
			Console.WriteLine("BytesToObject error:" + ex.Message);
			return null;
		}
	}
}
