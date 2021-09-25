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
    private Transform characterTransform;
    [SerializeField]
    private Transform cameraTransform;
    [SerializeField]
    private float projectileSpeed = 50f;
    [SerializeField]
    private bool isWalking, isJumping = false, isGrounded, isAttackPressed, isShooting = false; 
    private string currentState;
    private float targetAngle;
    private Vector3 velocity;
    [SerializeField]
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBarScript healthBar;
    private int bulletCount = 0;

    public GameObject projectile;
    public Transform firingPoint;
    public Transform target;
    void Start()
    {
        playerVelocity = GetComponent<IVelocity>();
        playerAnimator = GetComponentInChildren<Animator>();
        playerRotation = GetComponent<IRotation>();
        playerJump = GetComponent<IJump>();
        ground = GetComponent<GroundCheck>();
        characterTransform = transform.GetChild(0);
        cameraTransform = transform.GetChild(1);
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    void Update() // Update is called once per frame
    {
        velocity = Vector3.zero;
        velocity.x = Input.GetAxisRaw("Horizontal");
        velocity.z = Input.GetAxisRaw("Vertical");
        targetAngle = Mathf.Atan2(velocity.x, velocity.y) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
        if (velocity != Vector3.zero) {
            isWalking = true;
            velocity = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        } 
        else {
            isWalking = false;
        }
        if (Input.GetKey(KeyCode.Space)) {
            isJumping = true;
        }
        if (Input.GetKey(KeyCode.Mouse0)) {
            isAttackPressed = true;
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
        playerRotation.SetRotation(targetAngle);
        
        if (!isAttackPressed) {
            if (isWalking && isGrounded) {
                ChangeAnimationState("WALK");
            }
            if (!isWalking && isGrounded) {
                ChangeAnimationState("IDLE");
            }
        }
        if (isAttackPressed) {
            isAttackPressed = false;
            if (!isShooting) {
                ShootProjectile();
                isShooting = true;
                ChangeAnimationState("SHOOT");            
            }
            float attackDelay = playerAnimator.GetCurrentAnimatorStateInfo(0).length;
            Invoke("shootingComplete", attackDelay);
            bulletCount = 0;
        }
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
    void shootingComplete(){
        isShooting = false;
    }
    public void ChangeAnimationState(string newState) {
        if (currentState == newState ) return;
        playerAnimator.Play(newState);
        currentState = newState;
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Enemy")) {
            TakeDamage(5);
            if (currentHealth <= 0) {
                Debug.Log("Dead");
            }
        }
    }

    void ShootProjectile() {
        if (bulletCount < 1)
        {
            var bullet = Instantiate(projectile, firingPoint.position, transform.GetChild(0).rotation) as GameObject; 
            bullet.GetComponent<Rigidbody>().velocity = transform.GetChild(0).forward * projectileSpeed;
            Debug.Log(transform.GetChild(0).forward);
            bulletCount += 1;
        }
        
    }
}
