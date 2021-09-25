using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectSystem : MonoBehaviour
{
   public TMP_Text scoreText;
   public static int theScore;

   void Update()
   {
       scoreText.text = "Collected: " + theScore;
   }
}
