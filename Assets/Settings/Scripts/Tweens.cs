using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweens : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private Transform targetPosition;
    [SerializeField, Range(0, 1)] private float tparameter = 0;
    private float currentTime;
    private Vector3 inicialPosition;
    
    private void Start()
    {
        inicialPosition = transform.position;
    }

    // Update is called once per frame
   private  void Update()
    {

        tparameter = currentTime / time;
        transform.position = Vector3.Lerp(inicialPosition, targetPosition.position, tparameter);
        currentTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartTweens();
        }
    }

   private void StartTweens()
   {
       tparameter = 0;
       currentTime = 0;
       time = 1;
       inicialPosition = transform.position;
       //targetPosition = targetPosition.position;
   }
}