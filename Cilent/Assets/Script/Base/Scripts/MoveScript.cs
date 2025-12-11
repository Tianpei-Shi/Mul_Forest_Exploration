using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveScript : MonoBehaviour
{
    PlayerInput input;

    //地形
    public Terrain[] terrians;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        input = GetComponent<PlayerInput>();
        input.currentActionMap.Enable();


    }


    // Update is called once per frame
    void Update()
    {
        Vector2 vector2 = input.actions["Move"].ReadValue<Vector2>();
        transform.position += new Vector3(vector2.x, 0, vector2.y) * Time.deltaTime * 5;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //获取当前地形名称
        string terrainName = collision.gameObject.name;
        //重命名
        terrainName = terrainName.Replace("Terrain_(", "").Replace(")", "");
        //分割
        string[] pos = terrainName.Split(',');
        //得到偏移数据
        float x = float.Parse(pos[0]);
        float z = float.Parse(pos[2]);
        //计算出周围地形
        List<string> names = new List<string>();
        for (int i = -5; i <= 5; i += 5)
        {
            for (int j = -5; j <= 5; j += 5)
            {
                string tmp = $"Terrain_({x + i:0.00}, 0.00, {z + j:0.00})";
                Debug.Log(tmp);
                names.Add(tmp);
            }
        }
        //激活周围地面
        foreach (string name in names)
        {
            setTerrain(name, true);
        }

        //隐藏远处地面
        foreach(Terrain terrain in terrians)
        {
            if (!names.Contains(terrain.name))
            {
                setTerrain(terrain.name, false);
            }
        }
    }



    void setTerrain(string name, bool active)
    {
        foreach (Terrain terrain in terrians)
        {
            if (terrain.name == name)
            {
                terrain.gameObject.SetActive(active);
                return;
            }
        }
    }
}
