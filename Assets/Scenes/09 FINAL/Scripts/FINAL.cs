using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class FINAL : MonoBehaviour
{
    [Range(0,1)][SerializeField] private float Gravity = 9.8f; 
    [SerializeField] private float m_Mass;
    [SerializeField] private float r_Distance;
    [SerializeField] private float m_mass;
    [SerializeField] LineRenderer curve;
    private float energy;
    private MyVector aceleration;
    private MyVector velocity;
    private MyVector position;

    void Start()
    {
        curve = GetComponent<LineRenderer>();
        
        Vector3[] points = new Vector3[100];
        for (int i = 0; i < 100; i++)
        {
            r_Distance = 0.3f * i+0.1f;
            energy = ((Gravity *( m_mass )*( m_Mass))/ r_Distance);
            points[i]= new Vector3(r_Distance,energy,0);
        } 
        curve.SetPositions(points);
    }


    void Update()
    {
         /*r_Distance = transform.position.x;
         energy = ((Gravity *( m_mass )*( m_Mass))/ r_Distance);
         MyVector position = transform.position;
         position.y = energy;
         transform.position=position;*/

    }
}