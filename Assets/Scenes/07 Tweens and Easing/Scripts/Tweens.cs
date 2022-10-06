using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweens : MonoBehaviour
{
    [SerializeField]  float time;
    [SerializeField] Transform targetTransform;
    [SerializeField, Range(0, 1)]  float tparameter = 0;
    [SerializeField] private Color inicialColor;
    [SerializeField] private Color finalColor;
    private float currentTime;
    private Vector3 inicialPosition;
    private Vector3 targetPosition;
    private SpriteRenderer spriteRenderer;

    
   private void Start()
   {
       spriteRenderer = GetComponent<SpriteRenderer>();
   }

    // Update is called once per frame
    private void Update()
    {
        tparameter = currentTime / time;
        transform.position = Vector3.Lerp(inicialPosition, targetPosition, tparameter);
       spriteRenderer.color = Color.Lerp(inicialColor, finalColor, tparameter);
        currentTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartTween();
        }
    }

    private void StartTween()
    {
        tparameter = 0;
        currentTime = 0;
        inicialPosition = transform.position;
        targetPosition = targetTransform.position;
    }
}
