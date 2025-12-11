using System;
using System.Collections.Generic;
using UnityEngine;

public class UserManager : MonoBehaviour, IMessage
{
	//保存所有玩家信息
	public static Dictionary<int, PlayerCon> idUserDic = new Dictionary<int, PlayerCon>();
    //保存当前客户端角色id
    public static int ID;
    public static PlayerCon user;
    //获取当前角色
    public static PlayerCon User{
        get{
            if(user == null){
                idUserDic.TryGetValue(ID, out user);
			}
            return user;
		}
	}

	void Start()
	{
        Client.AddListener(this);
	}

	public void Receive(myMessage msg)
	{
		if(msg.type == myMessage.Type.Type_User)
		{
			switch (msg.command)
			{
				case myMessage.Type.User_SelectS:
					//创建自己的角色
					selectMyUser(msg);
					break;
				case myMessage.Type.User_CreateS:
					createOtherUser(msg);
					break;
				case myMessage.Type.User_RemoveS:
					removeOtherUser(msg);
					break;
			}
		}
	}

	private void removeOtherUser(myMessage msg)
	{
		int userid = msg.GetContent<int>(0);
		//从字典中删除
		PlayerCon user = idUserDic[userid];
		idUserDic.Remove(userid);
		//从场景中删除
		Destroy(user.gameObject);
	}

	//创建当前客户端自己的角色
	void selectMyUser(myMessage message)
	{
		int userid = message.GetContent<int>(0);
		int modelid = message.GetContent<int>(1);
		float[] point = message.GetContent<float[]>(2);
		if(userid > 0)
		{
			//创建角色
			GameObject userPre = Resources.Load<GameObject>("Player" + modelid.ToString());
			//实例化
			GameObject user = Instantiate(userPre, new Vector3(point[0], point[1], point[2]), Quaternion.identity);
			PlayerCon playerCon = user.GetComponent<PlayerCon>();
			playerCon.id = userid;
			ID = userid;
			//将自己的角色添加到角色字典中
			idUserDic.Add(userid, playerCon);
		}
		else
		{
			Debug.Log("创建角色失败");
		}
	}
	//创建其他玩家的角色
	void createOtherUser(myMessage message)
	{
		int userid = message.GetContent<int>(0);
		int modelid = message.GetContent<int>(1);
		float[] point = message.GetContent<float[]>(2);
		//创建角色
		GameObject userPre = Resources.Load<GameObject>("Player" + modelid.ToString());
		//实例化
		GameObject user = Instantiate(userPre, new Vector3(point[0], point[1], point[2]), Quaternion.identity);
		PlayerCon playerCon = user.GetComponent<PlayerCon>();
		playerCon.id = userid;
		//将自己的角色添加到角色字典中
		idUserDic.Add(userid, playerCon);
	}

}
