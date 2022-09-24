using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
/// Move at constant speed
public class Moover : MonoBehaviour
{
    private enum MovementMode
    {
        Velocity=0,
        Aceleration
    }
    public MyVector Velocity => velocity;
    [SerializeField] private MovementMode movementMode;
    [SerializeField] private Transform target;
    [SerializeField] private float speed;
    private MyVector aceleration;
    private MyVector velocity;
    private MyVector position;
 
    
         
    private void Start()
    {
        position = transform.position;
        //Time.maximumDeltaTime=(1f/60f);
    }
    
    // Update is called once per frame
    private void FixedUpdate()
    {
        //Debug Vectors
        position.Draw(Color.red);
        aceleration.Draw(position, Color.yellow);
        velocity.Draw(position, Color.white);
        
        switch (movementMode)
        {
           case MovementMode.Velocity:
               velocity = target.position - transform.position;
               velocity.Normalize();
               velocity *= speed;
               break;
               case MovementMode.Aceleration:
                   aceleration = target.position - transform.position;
                   break;
        }
        Move();
    }
    
    public void Move()
    {
        velocity = velocity + aceleration * Time.fixedDeltaTime;
        position = position + velocity * Time.fixedDeltaTime;
        transform.position = position;
    }
}

    