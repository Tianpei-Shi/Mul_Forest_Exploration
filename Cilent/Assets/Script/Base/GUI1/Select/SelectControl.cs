using UnityEngine;

public class SelectControl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform[] startPoint;
    void Start()
    {
        
    }

    public void SelectHero(int modelId)
    {
        //给服务器发消息，我要创建英雄角色
        Vector3 pos = startPoint[modelId - 1].position;
		myMessage msg = new myMessage(myMessage.Type.Type_User, myMessage.Type.User_SelectC, modelId, new float[] { pos.x, pos.y, pos.z });
        Client.Send(msg);
        Destroy(gameObject);
    }
}
