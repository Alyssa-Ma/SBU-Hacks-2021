   
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP1 : MonoBehaviour
{
    

    void OnTriggerEnter(Collider col)
    {
        col.transform.position = new Vector3 (39, 5, -79);
    }

}