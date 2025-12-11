using UnityEngine;
using UnityEngine.AI;

public class PlayerCon : MonoBehaviour
{
    //角色id
    public int id;
    //动画导航组件
    private Animator animator;
    private NavMeshAgent agent;

    //目标位置
    private Vector3 targetPosition;

    //死亡
    bool isDie = false;
	void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDie) return;
		//计算目标距离
		float dis = Vector3.Distance(transform.position, targetPosition);
        if (dis > 0.5f)
        {
            agent.isStopped = false;
            agent.SetDestination(targetPosition);
            animator.SetBool("isRun", true);
        }
        else
        {
            agent.isStopped = true;
            animator.SetBool("isRun", false);
        }
    }

    //移动
    public void Move(Vector3 target)
    {
        this.targetPosition = target;
    }

    public void Move(float[] target)
    {
        this.targetPosition = new Vector3(target[0], target[1], target[2]);
    }

	//攻击
	public void Attack(int targetId)
	{
		//被攻击者
		PlayerCon targetUser = UserManager.idUserDic[targetId];
		//攻击者朝向被攻击者
        this.transform.LookAt(targetUser.transform.position);
		//播放攻击动画
        animator.SetTrigger("Attack");
	}

    //死亡
    public void Die()
    {
        isDie = true;
        animator.SetTrigger("Die");
	}
}
