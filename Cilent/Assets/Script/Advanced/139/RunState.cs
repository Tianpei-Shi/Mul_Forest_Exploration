using UnityEngine;

public class RunState : FSMState
{
	public RunState(int stateID, MonoBehaviour mono, FSMManager manager) : base(stateID, mono, manager)
	{
	}

	public override void OnEnter()
	{
		mono.GetComponent<Animator>().SetBool("Run", true);
	}

	public override void OnUpdate()
	{
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
		Vector3 dir = new Vector3(horizontal, 0, vertical);
		if(dir == Vector3.zero)
		{
			FsmManager.ChangeState((int)PlayerState.idle);
		}
		else
		{
			mono.transform.rotation = Quaternion.LookRotation(dir);
			mono.transform.position += dir * Time.deltaTime * 3;
		}
	}
}
