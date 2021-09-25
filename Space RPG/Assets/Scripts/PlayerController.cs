using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private IVelocity playerVelocity;
    private IRotation playerRotation;
    
    private Animator playerAnimator;
    [SerializeField]
    private bool isWalking, isJump, isGround; 
    private string currentState;
    private Vector3 velocity;
    
    void Start()
    {
        playerVelocity = GetComponent<IVelocity>();
        playerAnimator = GetComponentInChildren<Animator>();
        playerRotation = GetComponent<IRotation>();
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
            isJump = true;
        }
    }
    void FixedUpdate() // physics & colliders
    { 
        if (isWalking) {
            playerVelocity.SetVelocity(velocity.normalized);
            playerRotation.SetRotation(velocity.normalized);
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
