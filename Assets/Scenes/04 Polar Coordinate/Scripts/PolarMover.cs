using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolarMover : MonoBehaviour
{
    [SerializeField] private MyVector polarCoo;

    [Header("Speed Controls")] 
    [SerializeField] private float angularSpeed;
    [SerializeField] private float radialSpeed;
    
    void Start()
    {
        
    }

   
   private void Update()
   {
      polarCoo.radius += radialSpeed * Time.deltaTime;
      polarCoo.angle += angularSpeed * Mathf.Deg2Rad*Time.deltaTime;
       transform.position = polarCoo.FromPolarToCartesian();
   }
}
