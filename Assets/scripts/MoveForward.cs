using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    [SerializeField] float m_Speed;
    [SerializeField] float m_MaxAngle = 25.0f;

    // The minimum and maximum rotation angles around the X-axis
    float m_MinRotationAngle = -15.0f;
    float m_MaxRotationAngle = 15.0f;

    // The initial rotation of the object
    Quaternion m_InitialRotation = Quaternion.Euler(-90f, 90f, -90f);

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get the object's velocity
        Vector3 velocity = m_Rigidbody.velocity;
        // Calculate the angle based on the velocity, with a maximum of m_MaxAngle
        float angle = Mathf.Clamp(velocity.magnitude * 0.5f, 0.0f, m_MaxAngle);
        // Calculate the rotation around the X-axis based on the angle
        float rotation = (velocity.x > 0) ? angle : -angle;

        // Clamp the rotation within the allowed range of angles
        float clampedRotation = Mathf.Clamp(rotation, m_MinRotationAngle, m_MaxRotationAngle);

        // Set the new rotation on the object, preserving the Y and Z components of the original rotation
        Quaternion targetRotation = Quaternion.Euler(m_InitialRotation.eulerAngles.x + clampedRotation, 90, -90);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 5.0f); // Change the last parameter for desired speed

        // Move left
        if (Input.GetKeyDown(KeyCode.A))
        {
            m_Rigidbody.AddForce(Vector3.left * m_Speed);
        }
        // Move right
        if (Input.GetKeyDown(KeyCode.D))
        {
            m_Rigidbody.AddForce(Vector3.right * m_Speed);
        }
    }
}