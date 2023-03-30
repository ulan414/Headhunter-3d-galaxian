using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateShip : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public float maxRotationAngle = 245f;
    private float rotationAngle = 125f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            RotateObject(rotationAngle);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            RotateObject(-rotationAngle);
        }
    }

    void RotateObject(float targetAngle)
    {
        targetAngle = Mathf.Clamp(targetAngle, -maxRotationAngle, maxRotationAngle);

        Quaternion targetRotation = Quaternion.Euler(0f, 0f, targetAngle);
        Quaternion currentRotation = transform.rotation;

        transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
}


