using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject projectile;
    public Transform firingPoint;
    public Vector3 target;
    [SerializeField]
    private float projectileSpeed = 50f;
    void ShootProjectile() {
        var bullet = Instantiate(projectile, firingPoint.position, Quaternion.identity) as GameObject; 
        bullet.GetComponent<Rigidbody>().velocity = (target - firingPoint.position).normalized * projectileSpeed;
    }
}
