using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuntionGrapgh : MonoBehaviour

{
    [SerializeField] private GameObject m_pointPrefab;
    [SerializeField] private int m_totalSamplesPoints = 10;
    [SerializeField] private float m_separation = 0.5f;
    GameObject[] m_points;
   
  private  void Start()
  {
      m_points = new GameObject[m_totalSamplesPoints];
        for (int i = 0; i < m_totalSamplesPoints; ++i)
        {
            m_points[i] = Instantiate(m_pointPrefab, transform);
        }
                    
    }
    
    private void UpdatePoints()
    {
        for (int i = 0; i < m_points.Length; ++i)
        {
            var newPoint = m_points[i];
            Vector3 currPosition = newPoint.transform.position;
            
            currPosition.x = i * m_separation;
            currPosition.y = Mathf.Sin(currPosition.x + Time.time);

            newPoint.transform.localPosition = currPosition;
            
        }
        
    }
    void Update()
    {
        UpdatePoints();
    }
}
