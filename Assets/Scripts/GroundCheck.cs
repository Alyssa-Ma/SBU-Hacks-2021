using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private LayerMask whatIsGround;
    private bool isGrounded;
    [SerializeField]
    private float colliderRadius = 0.025f;
    [SerializeField]
    private Vector3 offsetRight = new Vector3(0.145f, 0.015f, 0f);
    private Vector3 offsetLeft = new Vector3(-0.145f, 0.015f, 0f);
    private void Awake() 
    {
        whatIsGround = LayerMask.GetMask("groundMask");
    }
    public bool GetIsGround()
    {
        this.isGrounded = Physics.CheckSphere(transform.position + offsetRight, colliderRadius, whatIsGround) || Physics.CheckSphere(transform.position + offsetLeft, colliderRadius, whatIsGround);
        return this.isGrounded;
    }
    public void SetIsGround(bool value)
    {
        this.isGrounded = value;
    }
}
