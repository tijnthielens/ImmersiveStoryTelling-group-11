using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Light))] //VERPLICHT om een licht object te hebben
public class ChangeColor : MonoBehaviour
{
    // Start is called before the first frame update
    
     public Light targetlight;
    [SerializeField] Color color0;
    [SerializeField] Color color1;

     [SerializeField] Color lerpedColor;
    [SerializeField] float duration = 1;


     private void Awake() 
     {
     targetlight = GetComponent<Light>(); //auto find mijn licht als ik dit script dragg
     }

    void Update()
    {
            lerpedColor = Color.Lerp(color0, color1, Mathf.PingPong(Time.time, 1));
targetlight.color = lerpedColor;


        // if(targetlight != null)
        // {
        //     Color newcolor = new Color
        //     {
              
        //     };

        //     targetlight.color = newcolor;
        // }
    }


  
}


