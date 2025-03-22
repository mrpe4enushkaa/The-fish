using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public float minY = 0f;
    public float maxY = 2f;

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        desiredPosition.y = Mathf.Clamp(desiredPosition.y, minY, maxY);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
