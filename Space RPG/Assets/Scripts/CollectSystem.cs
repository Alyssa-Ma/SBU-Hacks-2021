using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectSystem : MonoBehaviour
{
   public GameObject collectText;
   public static int theScore;

   void Update()
   {
       collectText.GetComponent<Text>().text = "Collected: " + theScore;
   }
}