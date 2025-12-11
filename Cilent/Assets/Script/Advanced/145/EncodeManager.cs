using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class EncodeManager
{
	public static EncodeManager instance;

	public static EncodeManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new EncodeManager();
			}
			return instance;
		}
	}

	//MD5加密
	public string MD5Encode(string message)
	{
		byte[] b = Encoding.Default.GetBytes(message);
		MD5 md5 = new MD5CryptoServiceProvider();
		b = md5.ComputeHash(b);
		return System.BitConverter.ToString(b).Replace("-", "").ToLower();
	}

	//Base64加密

	public string Base64Encode(string message)
	{
		byte[] b = Encoding.UTF8.GetBytes(message);
		return System.Convert.ToBase64String(b);
	}

	//base64解密
	public string Base64Decode(string message)
	{
		byte[] b = System.Convert.FromBase64String(message);
		return Encoding.UTF8.GetString(b);
	}
}
