using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour, IJump
{
    private Rigidbody rb;
    [SerializeField]
    private float jumpForce = 5f;
    private void Awake() 
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
