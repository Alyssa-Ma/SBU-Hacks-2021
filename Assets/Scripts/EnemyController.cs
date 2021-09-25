using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private int HP = 5;
    private Animator enemyAnimator;
    private bool isWalking;
    public Transform player;
    public float moveSpeed = 4f;
    public string currentState;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyAnimator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (Mathf.Abs(Vector3.Distance(player.position, transform.position)) <= 10) {
            transform.LookAt(player, Vector3.up);
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
            isWalking = true;
        } else {
            isWalking = false;
        }
    }

    private void FixedUpdate() {
        if (isWalking) {
            ChangeAnimationState("RUN");
        } else {
            ChangeAnimationState("IDLE");
        }
    }
    public void ChangeAnimationState(string newState) {
        if (currentState == newState ) return;
        enemyAnimator.Play(newState);
        currentState = newState;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("bullet")) {
            HP -= 1;
        }
    }
}
