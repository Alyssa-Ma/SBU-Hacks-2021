using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour, IRotation
{
    public Transform characterTransform;
    public void SetRotation(Vector3 velocity) {
        if (velocity.x != 0 || velocity.z != 0) {
            characterTransform.rotation = Quaternion.LookRotation(velocity, Vector3.up);
        }
    }
}
