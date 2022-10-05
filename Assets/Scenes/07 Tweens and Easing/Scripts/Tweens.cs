using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tween : MonoBehaviour
{
    [SerializeField]  float time;
    [SerializeField] Transform targetPosition;
    [SerializeField, Range(0, 1)]  float tparameter = 0;
    private float currentTime;
     Vector3 inicialPosition;
    
    void Start()
    {
        inicialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime<time)
        {
            transform.position = Vector3.Lerp(inicialPosition, targetPosition.position, tparameter);
        }

        
        currentTime += Time.deltaTime;
    }
}
