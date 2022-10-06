using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillations : MonoBehaviour
{
    //[SerializeField, Range(0f, 10f)] private float displacementX;
    private Vector3 initialPotition;
    [SerializeField] private float period=3;
    [SerializeField] private float frecuency=3;
    

    private void Start()
    {
        initialPotition = transform.position;
    }

   
   private  void Update()
   {
       float noise = Mathf.Sin (4f*Time.time)+Mathf.Sin(2f*Time.time)+Mathf.Sin(3f*Time.time)+Mathf.Sin(7f*Time.time);
       transform.position = initialPotition + Vector3.right * Mathf.Sin(2f+Mathf.PI*(Time.time /period))*frecuency;
       
       transform.position = initialPotition + Vector3.right * noise * frecuency;
   }
}
