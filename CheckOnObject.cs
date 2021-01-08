using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.MonoBehaviour.TeleportMarkerBase;


public class CheckOnObject : MonoBehaviour
 {
     public Camera ThePlayer;
     public float Radius;
     //public TeleportPoint teleportPoint;

    
     void Update()
     {
         float dist = Vector3.Distance(ThePlayer.transform.position, transform.position);
 
         if (dist < Radius)
         {
            
           ThePlayer.GetComponent<LSDEffectManager>().SelectLSDCharacterEvent?.Invoke();
            //teleportPoint.Highlight(false);
            Destroy(this.gameObject);
        }
     }


   
 }


