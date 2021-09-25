using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP2 : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        col.transform.position = new Vector3 (-100, 80, -65);
    }
}
