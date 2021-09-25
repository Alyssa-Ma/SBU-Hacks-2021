using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVelocity : MonoBehaviour, IVelocity
{
    private Rigidbody rb;
    private Vector3 velocity;
    [SerializeField]
    private float speed = 5;
    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate() {
        float yVelocity = rb.velocity.y;
        this.velocity.y = yVelocity;
        rb.velocity = this.velocity;
    }
    public void SetVelocity(Vector3 velocity) {
        this.velocity = velocity * speed;
    }
}
