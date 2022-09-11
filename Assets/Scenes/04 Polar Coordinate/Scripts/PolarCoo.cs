using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolarCoo : MonoBehaviour
{
    [SerializeField] private float angleDeg;
    [SerializeField] private float radius = 1;
    [SerializeField] private float angularSpeed = 5;

    void Start()
    {

    }
    
    private void Update()
    {
        PolarToCartesian(angleDeg, radius).Draw(Color.red);
        angleDeg = angleDeg + angularSpeed * Time.deltaTime;

    }

    private MyVector PolarToCartesian(float angleDeg, float rad) 
    {
        float x = Mathf.Cos(angleDeg * Mathf.Deg2Rad);
        float y = Mathf.Sin(angleDeg * Mathf.Deg2Rad);
        return new MyVector(x * radius, y * radius);
       

    }


}
