using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLookAt : MonoBehaviour
{
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Fighter_03").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the direction to the target
        Vector3 direction = target.position - transform.position;

        // Create a rotation that points towards the target
        Quaternion lookRotation = Quaternion.LookRotation(direction);

        // Add the extra rotation by modifying the look rotation
        lookRotation *= Quaternion.Euler(0f, 90f, 0f); // Adds 90 degrees by the Y-axis
        lookRotation *= Quaternion.Euler(-90f, 0f, 0f); // Adds -90 degrees by the Z-axis

        // Set the rotation of the object to the modified look rotation
        transform.rotation = lookRotation;
    }
}
