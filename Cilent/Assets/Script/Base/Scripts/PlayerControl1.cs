using UnityEngine;

public class PlayerControl1 : MonoBehaviour
{
    private CharacterController player;
    
    void Start()
    {
		player = GetComponent<CharacterController>();
	}

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        //组建成一个向量
        Vector3 dir = new Vector3(horizontal, 0, vertical); 
        //移动
        //transform.Translate(dir * Time.deltaTime * 5f); //移动速度为5单位每秒
		transform.position += dir * Time.deltaTime * 5f; //移动速度为5单位每秒
        //使用角色控制器移动
        player.SimpleMove(dir * 5f); //移动速度为5单位每秒

	}
}
