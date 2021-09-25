using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallFinalArea : MonoBehaviour
{
    public GameObject obj;
    void Update()
    {
        if(CollectSystem.theScore == 1)
        {
            Destroy(gameObject);
        }
    }
}
