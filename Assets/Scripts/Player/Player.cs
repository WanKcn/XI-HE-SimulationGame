using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    // 俯视角移动 x，y
    public float moveSpeed = 5f;
    private float inputX;
    private float inputY;
    private Vector2 movementInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void PlayerInput()
    {
        // 只能水平垂直移动
        // if (inputY == 0)
        //     inputX = Input.GetAxisRaw("Horizontal");
        // if (inputX == 0)
        //     inputY = Input.GetAxisRaw("Vertical");
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");

        // 控制斜方向的移动速度稍微小于水平垂直移动速度
        if (inputX != 0 && inputY != 0)
        {
            inputX *= 0.6f;
            inputY *= 0.6f;
        }

        movementInput = new Vector2(inputX, inputY);
    }


    private void Movement()
    {
        // 俯视角移动坐标 现有坐标加上输入方向*移动速度
        // *Time.deltaTime 修正不同设备不同帧数的正常运行
        rb.MovePosition(rb.position + movementInput * moveSpeed * Time.deltaTime);
    }
}