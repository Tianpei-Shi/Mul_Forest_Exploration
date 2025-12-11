using UnityEngine;

public class WaveState : FSMState
{
	public WaveState(int stateID, MonoBehaviour mono, FSMManager manager) : base(stateID, mono, manager)
	{
	}

	public override void OnEnter()
	{
		mono.GetComponent<Animator>().SetTrigger("Wave");
	}

	public override void OnUpdate()
	{
		if(!mono.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Wave"))
		{
			//挥手完成后，自动切换到Idle状态
			FsmManager.ChangeState((int)PlayerState.idle);
		}
	}
	void Update()
	{
		FsmManager.Update();
	}
}
