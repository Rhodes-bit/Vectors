using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Satelite : MonoBehaviour
{
    public MyVector Velocity => velocity;
    [SerializeField] private Transform target;
    [SerializeField] private MyVector aceleration;
    [SerializeField] private MyVector velocity;
    private MyVector position;
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
    }

    private void FixedUpdate()
    {
        Move();
    }

  
    private void Update()
    {
       
        position.Draw(Color.red);
        displacement.Draw(position, Color.blue);
        aceleration.Draw(position, Color.yellow);
        velocity.Draw(position, Color.white);

        int a = 0;
        int c = ++a;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            velocity *= 0;
            aceleration = acelerations[(++CurrentAccelIndex) % acelerations.Length];
            
        }

       aceleration = target.position - transform.position;
   
    }

    public void Move()
    {
       
        velocity = velocity + aceleration * Time.deltaTime;
        displacement = velocity * (Time.deltaTime); 
        position = position + displacement;

        transform.position = position;
    }
}