using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLamp : MonoBehaviour
{

    public float _Angle;
    public float _Period;
    private float _Time;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    _Time = _Time + Time.deltaTime;
    float phase = Mathf.Sin(_Time / _Period);
    transform.localRotation = Quaternion.Euler( new Vector3(phase * _Angle, 0, 0));
    }
}


//check