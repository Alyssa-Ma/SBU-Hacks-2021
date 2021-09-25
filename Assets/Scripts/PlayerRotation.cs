using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour, IRotation
{
    public Transform characterTransform;
    public Transform cameraTransform;
    public float smoothVelocity = 0.1f;
    public float turnsmoothVelocity;
    public void SetRotation(float targetAngle) {
        float angle = Mathf.SmoothDampAngle(characterTransform.eulerAngles.y, targetAngle, ref turnsmoothVelocity, smoothVelocity);
        characterTransform.rotation = Quaternion.Euler(0f, angle, 0f);
    }
}
