using UnityEngine;

public enum PlayerState
{
	idle,
	run,
	wave
}
public abstract class FSMState
{
	//当前状态
	public int StateID;
	//状态所属管理器
	public MonoBehaviour mono;
	//状态所属管理器
	public FSMManager FsmManager;

	public FSMState(int stateID, MonoBehaviour mono, FSMManager manager)
	{
		StateID = stateID;
		this.mono = mono;
		this.FsmManager = manager;
	}

	public abstract void OnEnter();
	public abstract void OnUpdate();
}
