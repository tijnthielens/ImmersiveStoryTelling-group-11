using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkteleport : MonoBehaviour
{     public GameObject ThePlayer;
     public float Radius;
 
     void Update()
     {
         float dist = Vector3.Distance(ThePlayer.transform.position, transform.position);
 
         if (dist < Radius)
         {
             // the player is within radius distance of this object
         }
     }
}
