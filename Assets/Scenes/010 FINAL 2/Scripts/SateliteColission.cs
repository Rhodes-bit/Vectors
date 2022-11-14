using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SateliteColission : MonoBehaviour
{  
    public MyVector Velocity => velocity;
    [SerializeField]  float time;
    [SerializeField] Transform targetTransform;
    private MyVector aceleration;
    private MyVector velocity;
    private MyVector position;

    private bool isLanding;
    float tparameter = 0;
    private float currentTime;
    private Vector3 inicialPosition;
    private Vector3 targetPosition;

    private void Start()
    {
        position = transform.position;
    
    }

    private void FixedUpdate()
    {
        if (!isLanding)
        {
            Move(); 
        }

       
    }

    
    private void Update()
    {
       
        position.Draw(Color.red);
        aceleration.Draw(position, Color.yellow);
        velocity.Draw(position, Color.blue);

        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isLanding)
            {
                StartTween();
            }

            isLanding = !isLanding;
        }

        if (isLanding)
        {
            currentTime += Time.deltaTime;
            tparameter = currentTime / time;
            transform.position = Vector3.Lerp(inicialPosition, targetPosition, EaseOutSine(tparameter));
        }
        else
        {
            aceleration = targetTransform.position - transform.position;
        }
        
       
      
    }

    public void Move()
    { 
        velocity = velocity + aceleration * Time.deltaTime;
        position = position + velocity * Time.deltaTime; 
        transform.position = position;
        float radians = Mathf.Atan2(velocity.y, velocity.x);
        RotateZ(radians);
    }
    private void StartTween()
    {
        tparameter = 0;
        currentTime = 0;
        inicialPosition = transform.position;
        targetPosition = targetTransform.position;
    }
    
    private float  EaseOutSine(float x)
    {
        return 1f - Mathf.Cos((x * Mathf.PI) / 2f);
    }
    private void RotateZ(float radians)
    {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, radians * Mathf.Rad2Deg);
    }
}
