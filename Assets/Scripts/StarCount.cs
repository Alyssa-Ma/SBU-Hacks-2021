using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCount : MonoBehaviour
{
    public AudioSource collectSound;

   void OnTriggerEnter(Collider other)
   {
       collectSound.Play();
       CollectSystem.theScore += 1;
       Destroy(gameObject);
   }
}
