using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TestVelocity : MonoBehaviour
{
    
     private MyVector aceleration;
     private MyVector position;
     private MyVector velocity;
     private MyVector displacement;

     private int CurrentAccelIndex = 0;

     private MyVector[] acelerations = new MyVector[4]
     {
         new MyVector(0f,-9.8f),
         new MyVector(9.8f, -0f),
         new MyVector(0f,9.8f),
         new MyVector(-9.8f, -0f) 

     };
         
   private void Start()
    {
        position = transform.position;
        //Time.maximumDeltaTime=(1f/60f);
    }

   private void FixedUpdate()
   {
       Move();
   }

   // Update is called once per frame
    private void Update()
    {
        //Debug Vectors
        position.Draw(Color.red);
        displacement.Draw(position, Color.blue);
        aceleration.Draw(position, Color.yellow);
        velocity.Draw(position, Color.cyan);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            velocity *= 0;
            aceleration = acelerations[(CurrentAccelIndex++) % acelerations.Length];
            
        }
        Move();
        Debug.Log(Time.deltaTime);
    }

    public void Move()
    {
        transform.position = position;
        velocity = velocity + aceleration * Time.deltaTime;
        displacement = velocity * (Time.deltaTime); //deltaTIME (1f/60f)
        position = position + displacement;

       if (position.x < -5 || position.x > 5) 
        {
            position.x = Mathf.Sign(position.x)*5;
            velocity.x = -velocity.x;
        }
       if (position.y < -5 || position.y > 5) 
       {
           position.y = Mathf.Sign(position.y)*5;
           velocity.y = -velocity.y;
       }
       
     
      
        transform.position = position;
    }
}
