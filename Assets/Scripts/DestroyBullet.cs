using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    private void Start() {
        StartCoroutine(SelfDestruct());
    }
    IEnumerator SelfDestruct() {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag != "Player" && other.gameObject.tag != "Bullet") {
            Destroy(gameObject);
        }
    }
}
