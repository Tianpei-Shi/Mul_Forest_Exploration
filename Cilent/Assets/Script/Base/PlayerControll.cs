using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControll : MonoBehaviour
{
    private Animator anim;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        anim = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
        //获取水平轴
        float horizontal = Input.GetAxis("Horizontal");
		//获取垂直轴
        float vertical = Input.GetAxis("Vertical");
        //向量
        Vector3 dir = new Vector3(horizontal, 0, vertical);

        if (dir != Vector3.zero)
        {
			//面向向量
			transform.rotation = Quaternion.LookRotation(dir);
			//移动
			transform.position += dir * Time.deltaTime * 5;
            //播放跑步动画
            anim.SetBool("isrun", true);
        }
        else
        {
			//播放站立动画
            anim.SetBool("isrun", false);
		}
	}
}
