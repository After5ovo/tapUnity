using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 2;
    public float runSpeed = 6;

    private CharacterController characterController;
    private Animator animator;
    Transform cameraT;


    /// <summary>
    /// 控制角色行为，旋转，移动
    /// </summary>
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        cameraT = Camera.main.transform;
    }

    void Update()
    {
        //获取玩家输入
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector2 inputDir = input.normalized;
        //根据输入旋转移动角色
        if (inputDir != Vector2.zero)
        {
            transform.eulerAngles = Vector3.up * ((Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg)+ cameraT.eulerAngles.y);
        }

        bool running = Input.GetKey(KeyCode.LeftShift);

        float speed = ((running) ? runSpeed : walkSpeed)* inputDir.magnitude;

        Vector3 velocity = transform.forward * speed;

        characterController.Move(velocity * Time.deltaTime);

        //控制动画播放
        float animationSpeedPercent = ((running) ? 1 : 0.5f) * inputDir.magnitude;
        animator.SetFloat("SpeedPercent", animationSpeedPercent);
    }
}
