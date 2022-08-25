using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestV2 : MonoBehaviour

{
    [SerializeField]
    private MyVector myFirstVector;
    
    [SerializeField]
    private MyVector mySecondVector;
    
    [Range(-1, 1), SerializeField] private float DistanceVectors;
    
    
    void Update()
    {
        myFirstVector.Draw(Color.yellow);
        mySecondVector.Draw(Color.blue);
        
        MyVector diff = (mySecondVector - myFirstVector) * DistanceVectors;
        diff.Draw(myFirstVector,Color.red);
        
        MyVector lerp = myFirstVector + diff;
        lerp.Draw(Color.red);
    }
}

