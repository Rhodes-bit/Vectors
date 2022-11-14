using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class SateliteGraph : MonoBehaviour
{
    
    
    [SerializeField]  float time;
    [SerializeField] Transform targetTransform;
    [SerializeField, Range(0, 1)]  float tparameter = 0;
    [SerializeField] private Color inicialColor;
    [SerializeField] private Color finalColor;
    [SerializeField] private AnimationCurve curve;
    private float currentTime;
    private Vector3 inicialPosition;
    private Vector3 targetPosition;
    private SpriteRenderer spriteRenderer;

    
   private void Start()
   {
       spriteRenderer = GetComponent<SpriteRenderer>();
   }
   
    private void Update()
    {
        tparameter = currentTime / time;
        transform.position = Vector3.Lerp(inicialPosition, targetPosition, EaseOutSine(tparameter));
        spriteRenderer.color = Color.Lerp(inicialColor, finalColor, EaseOutSine(tparameter));
        
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
    
    private float  EaseOutSine(float x)
    {
        return 1f - Mathf.Cos((x * Mathf.PI) / 2f);
    }

   
}
