using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransform : MonoBehaviour
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
        //Debug.Log(phase);

        transform.localScale += new Vector3(phase * _Angle, 0, 0);
    }    
}
