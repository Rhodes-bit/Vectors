using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class FINAL : MonoBehaviour
{
    [Range(0, 1)][SerializeField] private float Gravity = 1f;
    [SerializeField] private float m_Mass;
    [SerializeField] private float m_mass;
    [SerializeField] Transform planet;
    LineRenderer curve;

    private void Start()
    {
        curve = GetComponent<LineRenderer>();
        curve.positionCount = 100;
    }

    private void Update()
    {
        for (int i = 0; i < curve.positionCount; i++)
        {
            float distance = 0.1f + 0.3f * i ;
            float energy = -Gravity * m_mass * m_Mass / distance;
            Vector3 point = new Vector3(planet.position.x + distance, energy, 0);
            curve.SetPosition(i, point);
        }
    }
}