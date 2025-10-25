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
    /// ���ƽ�ɫ��Ϊ����ת���ƶ�
    /// </summary>
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        cameraT = Camera.main.transform;
    }

    void Update()
    {
        //��ȡ�������
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector2 inputDir = input.normalized;
        //����������ת�ƶ���ɫ
        if (inputDir != Vector2.zero)
        {
            transform.eulerAngles = Vector3.up * ((Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg)+ cameraT.eulerAngles.y);
        }

        bool running = Input.GetKey(KeyCode.LeftShift);

        float speed = ((running) ? runSpeed : walkSpeed)* inputDir.magnitude;

        Vector3 velocity = transform.forward * speed;

        characterController.Move(velocity * Time.deltaTime);

        //���ƶ�������
        float animationSpeedPercent = ((running) ? 1 : 0.5f) * inputDir.magnitude;
        animator.SetFloat("SpeedPercent", animationSpeedPercent);
    }
}
