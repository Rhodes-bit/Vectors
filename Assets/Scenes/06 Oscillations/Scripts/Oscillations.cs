using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillations : MonoBehaviour
{
    //[SerializeField, Range(0f, 10f)] private float displacementX;
    private Vector3 initialPotition;
    [SerializeField] private float speed=3;

    private void Start()
    {
        initialPotition = transform.position;
    }

   
   private  void Update()
   {
       transform.position = initialPotition + (Vector3.right + Vector3.up) * Mathf.Sin(Time.time) * speed;
       // transform.position += Vector3.up * Mathf.Sin(Time.time);
       //transform.position= new Vector3 (Mathf.Sin(Time.time),transform.position.y,transform.position.z);
   }
}
