using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweens : MonoBehaviour
{
    public enum EasingFuntions
    {
        EaseInOutBounce,
        EaseInQuad,
        EaseInCubic,
        EaseOutSine,
        EaseInOutElastic,
        EaseOutBounce,
        CustomCurve,
    }

    [SerializeField] private EasingFuntions easing;
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
        int i = (int)easing;
        switch(i) 
        {
            case  0:
                tparameter = currentTime / time;
                transform.position = Vector3.LerpUnclamped(inicialPosition, targetPosition, EaseInOutBounce(tparameter));
                spriteRenderer.color = Color.LerpUnclamped(inicialColor, finalColor, EaseInOutBounce(tparameter));
                break;
            case 1:
                tparameter = currentTime / time;
                transform.position = Vector3.LerpUnclamped(inicialPosition, targetPosition, EaseInQuad(tparameter));
                spriteRenderer.color = Color.LerpUnclamped(inicialColor, finalColor, EaseInQuad(tparameter));
                break;
           case 2:
               tparameter = currentTime / time;
               transform.position = Vector3.LerpUnclamped(inicialPosition, targetPosition, EaseInCubic(tparameter));
               spriteRenderer.color = Color.LerpUnclamped(inicialColor, finalColor, EaseInCubic(tparameter));
               break;
            case 3:
                tparameter = currentTime / time;
                transform.position = Vector3.LerpUnclamped(inicialPosition, targetPosition, EaseOutSine(tparameter));
                spriteRenderer.color = Color.LerpUnclamped(inicialColor, finalColor, EaseOutSine(tparameter));
                break;
            case 4:
                tparameter = currentTime / time;
                transform.position = Vector3.LerpUnclamped(inicialPosition, targetPosition, EaseInOutElastic(tparameter));
                spriteRenderer.color = Color.LerpUnclamped(inicialColor, finalColor, EaseInOutElastic(tparameter));
                break;
            case 5:
                tparameter = currentTime / time;
                transform.position = Vector3.LerpUnclamped(inicialPosition, targetPosition, EaseOutBounce(tparameter));
                spriteRenderer.color = Color.LerpUnclamped(inicialColor, finalColor, EaseOutBounce(tparameter));
                break;
            case 6:
                tparameter = currentTime / time;
                transform.position = Vector3.LerpUnclamped(inicialPosition, targetPosition, curve.Evaluate(tparameter));
                spriteRenderer.color = Color.LerpUnclamped(inicialColor, finalColor, curve.Evaluate(tparameter));
                break;
        }
        
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

    private float EaseInOutBounce(float x)
    {
        return x < 0.5f
            ? (1f - EaseOutBounce(1f - 2f * x)) / 2f
            : (1f + EaseOutBounce(2f * x - 1f)) / 2f;
    }
    private float  EaseInQuad(float x)
    {
        return x * x;
    }
    private float  EaseInCubic(float x)
    {
        return x * x * x;
    }
    private float  EaseOutSine(float x)
    {
        return 1f - Mathf.Cos((x * Mathf.PI) / 2f);
    }

    private float EaseOutBounce(float x)
    {
       float n1 = 7.5625f;
       float d1 = 2.75f;

        if (x < 1 / d1) {
            return n1 * x * x;
        } else if (x < 2 / d1) {
            return n1 * (x -= 1.5f / d1) * x + 0.75f;
        } else if (x < 2.5 / d1) {
            return n1 * (x -= 2.25f / d1) * x + 0.9375f;
        } else {
            return n1 * (x -= 2.625f / d1) * x + 0.984375f;
        }
    }
    private float EaseInOutElastic(float x)
    {
        float c5 = (2f * Mathf.PI) / 4.5f;

        return x == 0f
            ? 0f
            : x == 1f
                ? 1f
                : x < 0.5f
                    ? -(Mathf.Pow(2f, 20f * x - 10f) * Mathf.Sin((20f * x - 11.125f) * c5)) / 2f
                    : (Mathf.Pow(2f, -20f * x + 10f) * Mathf.Sin((20f * x - 11.125f) * c5)) / 2f + 1f;
    }
}
