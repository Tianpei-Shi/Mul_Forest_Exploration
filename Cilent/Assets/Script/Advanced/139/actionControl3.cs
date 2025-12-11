using NUnit.Framework.Interfaces;
using System.Collections;
using UnityEngine;


public class actionControl3 : MonoBehaviour
{
	private FSMManager FsmManager;

	void Start()
	{
		//创建状态机管理器
		FsmManager = new FSMManager();

		//创建3个状态
		IdleState idle = new IdleState(0, this, FsmManager);
		RunState run = new RunState(1, this, FsmManager);
		WaveState wave = new WaveState(2, this, FsmManager);
		//将状态添加到状态机管理器中
		FsmManager.StateList.Add(idle);
		FsmManager.StateList.Add(run);
		FsmManager.StateList.Add(wave);
		//给一个默认状态
		FsmManager.ChangeState((int)PlayerState.idle);
	}
}
