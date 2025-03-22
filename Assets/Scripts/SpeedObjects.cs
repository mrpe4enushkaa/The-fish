using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedObjects : MonoBehaviour
{
    public float speedForce;

    public float rotationSpeed;


    private void Start()
    {
        speedForce = Random.Range(-4, -8);

        rotationSpeed = Random.Range(-60, 60);
    }

    private void Update()
    {
        Vector3 currentRotation = transform.rotation.eulerAngles;
        float newZRotation = currentRotation.z + rotationSpeed * Time.deltaTime;
        Vector3 newRotation = new Vector3(currentRotation.x, currentRotation.y, newZRotation);
        transform.rotation = Quaternion.Euler(newRotation);
    }

    private void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x + speedForce * Time.deltaTime, transform.position.y);
    }
}