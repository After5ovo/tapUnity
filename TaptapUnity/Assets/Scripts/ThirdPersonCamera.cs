using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 控制第三人称摄像机
/// </summary>
public class ThirdPersonCamera : MonoBehaviour
{
    public float mouseSensitivity = 10;
    public Transform target;
    public float offset = 2;
    public Vector2 pitchMinMax = new Vector2(-30, 70);
    public bool lockCursor;

    float yaw = 0;
    float pitch = 0;

    void Start()
    {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void Update()
    {
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y")* mouseSensitivity;
        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);

        Vector3 targetRotation= new Vector3(pitch, yaw);

        transform.eulerAngles = targetRotation;
        transform.position = target.position - transform.forward * offset;

    }
}
