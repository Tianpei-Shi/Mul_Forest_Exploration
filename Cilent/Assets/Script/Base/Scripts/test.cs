using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 V3 = new Vector3(60, 45, 0);
        Quaternion quaternion = Quaternion.identity;
        quaternion = Quaternion.Euler(V3);
        Debug.Log(quaternion.eulerAngles);
        Vector3 direm = Vector3.left;
        quaternion = Quaternion.LookRotation(direm);
        Debug.Log(quaternion.eulerAngles);
        //朝向敌人的向量
        Vector3 dir = new Vector3(1, 0, 0);
        quaternion = Quaternion.LookRotation(dir);
        Debug.Log(quaternion.eulerAngles);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
