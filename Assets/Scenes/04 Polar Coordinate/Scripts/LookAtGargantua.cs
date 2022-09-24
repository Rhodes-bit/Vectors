using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookAtGargantua : MonoBehaviour
{
    [SerializeField] private Moover mover ;
    private Vector3 direction;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        direction = mover.Velocity; 
        float radians = Mathf.Atan(mover.Velocity.y / mover.Velocity.x);
        RotateZ(radians);
      
    }
   
    private void RotateZ(float radians)
    {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, radians * Mathf.Rad2Deg);
    }
}
