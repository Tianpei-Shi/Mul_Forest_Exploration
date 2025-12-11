using System;
using UnityEngine;

public class IdleState : FSMState
{
	public IdleState(int stateID, MonoBehaviour mono, FSMManager manager) : base(stateID, mono, manager)
	{

	}

	public override void OnEnter()
	{
		mono.GetComponent<Animator>().SetBool("Run", false);
	}

	public override void OnUpdate()
	{
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
		Vector3 dir = new Vector3(horizontal, 0, vertical);
		if(dir != Vector3.zero)
		{
			FsmManager.ChangeState((int)PlayerState.run);
		}

		//判断是否挥手
		if (Input.GetKeyDown(KeyCode.F))
		{
			FsmManager.ChangeState((int)PlayerState.wave);

		}
	}


}
