using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float turnSpeed = 5;
    private Vector3 offsetX;
    void Start()
    {
        offsetX = new Vector3(0f, 2.5f, -7.5f);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    void LateUpdate()
    {
        float xAngle = Input.GetAxis("Mouse X") ;
        offsetX = Quaternion.AngleAxis(xAngle * turnSpeed, Vector3.up) * offsetX;
        transform.position = player.position + offsetX;
        transform.LookAt(player.position);
    }
}
