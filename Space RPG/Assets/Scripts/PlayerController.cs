using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isWalk;
    public bool isJump;
    public bool isGround; 
    void Start()
    {
        
    }
    void Update() // Update is called once per frame
    {
        Vector3 velocity = Vector3.zero;
        velocity.x = Input.GetAxis("Horizontal");
        velocity.z = Input.GetAxis("Vertical");
        if (velocity != Vector3.zero) {
            isWalk = true;
        } 
        else {
            isWalk = false;
        }
        if (Input.GetKey(KeyCode.Space)) {
            isJump = true;
        }
    }
    void FixedUpdate() // physics & colliders
    { 

    }
}
