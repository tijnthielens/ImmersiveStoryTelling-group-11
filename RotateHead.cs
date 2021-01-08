using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHead : MonoBehaviour
{
    // Start is called before the first frame update

    public float rotateSpeed = 50; 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World);
    }
}
