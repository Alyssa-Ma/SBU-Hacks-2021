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
    private bool isWalking, isJumping = false, isGrounded; 
    private string currentState;
    private Vector3 velocity;
    
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
        
        if (isWalking && isGrounded) {
            ChangeAnimationState("WALK");
        }
        if (!isWalking) {
            ChangeAnimationState("IDLE");
        }
    }

    public void ChangeAnimationState(string newState) {
        if (currentState == newState ) return;
        playerAnimator.Play(newState);
        currentState = newState;
    }
}
