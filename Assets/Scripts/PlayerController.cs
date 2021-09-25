using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private IVelocity playerVelocity;
    private IRotation playerRotation;
    private IJump playerJump;
    private Animator playerAnimator;
    private GroundCheck ground;
    [SerializeField]
    private bool isWalking, isJumping = false, isGrounded, isShooting = false; 
    private string currentState;
    private Vector3 velocity;
    [SerializeField]
    private int HP = 20;
    void Start()
    {
        playerVelocity = GetComponent<IVelocity>();
        playerAnimator = GetComponentInChildren<Animator>();
        playerRotation = GetComponent<IRotation>();
        playerJump = GetComponent<IJump>();
        ground = GetComponent<GroundCheck>();
    }
    void Update() // Update is called once per frame
    {
        velocity = Vector3.zero;
        velocity.x = Input.GetAxis("Horizontal");
        velocity.z = Input.GetAxis("Vertical");
        if (velocity != Vector3.zero) {
            isWalking = true;
        } 
        else {
            isWalking = false;
        }
        if (Input.GetKey(KeyCode.Space)) {
            isJumping = true;
        }
        if (Input.GetKey(KeyCode.Mouse0)) {
            isShooting = true;
        }
    }
    void FixedUpdate() // physics & colliders
    { 
        isGrounded = ground.GetIsGround();
        if (isJumping && isGrounded) {
            playerJump.Jump();
            isJumping = false;
        }
        playerVelocity.SetVelocity(velocity.normalized);
        playerRotation.SetRotation(velocity.normalized);
        
        if (!isShooting) {
            if (isWalking && isGrounded) {
                ChangeAnimationState("WALK");
            }
            if (!isWalking && isGrounded) {
                ChangeAnimationState("IDLE");
            }
        }
        if (isShooting) {
            ChangeAnimationState("SHOOT");
            isShooting = false;
        }
    }

    public void ChangeAnimationState(string newState) {
        if (currentState == newState ) return;
        playerAnimator.Play(newState);
        currentState = newState;
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Enemy")) {
            HP -= 1;
            if (HP <= 0) {
                Debug.Log("Dead");
            }
        }
    }
}
