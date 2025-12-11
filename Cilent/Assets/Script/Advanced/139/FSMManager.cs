using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class FSMManager
{
	//状态列表
	public List<FSMState> StateList = new List<FSMState>();
	//当前状态ID
	public int CurrentStateID = -1;
	
	//改变状态
	public void ChangeState(int stateID)
	{
		CurrentStateID = stateID;
		//执行一次该状态的进入方法
		StateList[CurrentStateID].OnEnter();
	}

	//更新当前状态
	public void Update()
	{
		if (CurrentStateID >= 0 && CurrentStateID < StateList.Count)
		{
			StateList[CurrentStateID].OnUpdate();
		}
	}
}


