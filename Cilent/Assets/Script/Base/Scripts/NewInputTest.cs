using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewInputTest : MonoBehaviour
{
    PlayerInput input;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        input = GetComponent<PlayerInput>();
        //切换到指定的ActionMap
        // input.SwitchCurrentActionMap("");
        //开启该操作
        input.currentActionMap.Enable();
        //跳跃
        input.actions["Jump"].performed += Jump;
    }
    private void Jump(InputAction.CallbackContext obj)
    {
        Debug.Log("跳跃");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
