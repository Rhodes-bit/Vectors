using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.WebCam;

public class LookOrigin : MonoBehaviour
{
    private Vector3 OriginOffset;
    void Start()
    {
        OriginOffset = transform.position - Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Vector4 mouseWorldPosition = GetWorldMousePosition();
        Vector3 mousePositionRelative = (Vector3)mouseWorldPosition - transform.position;
        float radians = Mathf.Atan(mousePositionRelative.y / mousePositionRelative.x);
        RotateZ(radians);
       
    }
    private Vector4 GetWorldMousePosition()
    {
        Camera camera = Camera.main;
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane);
        Vector4 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        print(worldPos);
        return worldPos;
    }
    private void RotateZ(float radians)
    {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, radians * Mathf.Rad2Deg);
    }
}
