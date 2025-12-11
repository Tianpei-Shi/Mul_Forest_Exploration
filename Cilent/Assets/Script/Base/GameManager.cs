using RPGCharacterAnims.Actions;
using System;
using UnityEngine;

public class GameManager : MonoBehaviour, IMessage
{
	public void Receive(myMessage msg)
	{
		if(msg.type == myMessage.Type.Type_Game)
		{
			switch (msg.command)
			{
				case myMessage.Type.Game_MoveS:
					Move(msg);
					break;
				case myMessage.Type.Game_AttackS:
					Attack(msg);
					break;
			}
		}
	}

	private void Attack(myMessage msg)
	{
		int id = msg.GetContent<int>(0);
		int targetId = msg.GetContent<int>(1);
		int hp = msg.GetContent<int>(2);

		//攻击
		UserManager.idUserDic[id].Attack(targetId);

		//判断是否死亡
		if(hp <= 0)
		{
			UserManager.idUserDic[targetId].Die();
		}

	}

	private void Move(myMessage msg)
	{
		//用户id
		int userid = msg.GetContent<int>(0);

		//位置
		float[] targetPos = msg.GetContent<float[]>(1);

		//拿到用户控制器
		PlayerCon user = UserManager.idUserDic[userid];

		user.Move(targetPos);
	}

	void Start()
    {
        Client.AddListener(this);

	}


    void Update()
    {
		if (Input.GetMouseButtonDown(1))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit))
			{
				//如果点到地面
				if(hit.collider.tag == "Ground"){
					//发送消息给服务器,我要移动了
					Vector3 point = hit.point;
					Client.Send(new myMessage(myMessage.Type.Type_Game, myMessage.Type.Game_MoveC, UserManager.User.id, new float[] { point.x, point.y, point.z }));
				}

				//如果点到敌人
				if(hit.collider.tag == "Player")
				{
					//如果距离符合3米攻击范围
					float dis = Vector3.Distance(hit.point, UserManager.User.transform.position);
					if(dis > 0.2f && dis < 3f)
					{
						PlayerCon targetUser = hit.collider.GetComponent<PlayerCon>();
						//发送消息给服务器,我要攻击了
						Client.Send(new myMessage(myMessage.Type.Type_Game, myMessage.Type.Game_AttackC, targetUser.id));
					}
				}
			}
		}
    }
}
