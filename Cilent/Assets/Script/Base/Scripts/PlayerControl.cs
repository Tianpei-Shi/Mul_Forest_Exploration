using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public Terrain[] terrains;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //当前地形的名称
        string name = collision.gameObject.name;
        
    }
    // Update is called once per frame
    void Update()
    {
        //获取水平轴
        float horizontal = Input.GetAxis("Horizontal");
        //获取垂直轴
        float vertical = Input.GetAxis("Vertical");
        //得到一个玩家移动的向量
        Vector3 dir = new Vector3(horizontal, 0, vertical);
        if (dir != Vector3.zero)
        {
            //移动
            transform.Translate(dir * Time.deltaTime * 3);
        }
        

    }
}
