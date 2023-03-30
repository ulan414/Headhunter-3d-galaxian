using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Vector2 turn;
    public float sensitivity = .5f;
    public float speed = 1f;
    public GameObject spaceShip;
    public float cameraHeightOffset = 0.5f;
    public LayerMask ENEMY;

    private Vector3 targetPosition;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // rotation of the camera
        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        turn.y += Input.GetAxis("Mouse Y") * sensitivity;

        turn.x = Mathf.Clamp(turn.x, -60f, 60f);
        turn.y = Mathf.Clamp(turn.y, -40f, 30f);

        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);

        // Calculate the target position of camera based on the camera angle
        float offsetY = turn.y < -8f ? 2.68f - 3.5f : 2.68f;
        Vector3 targetY = spaceShip.transform.position + new Vector3(0, offsetY, -10.88f);
        Vector3 targetXY = targetY + transform.right * cameraHeightOffset;

        // move camera smoothly only in Y-axis
        targetPosition = new Vector3(transform.position.x, targetXY.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);

        // set the XZ position of camera instantly
        transform.position = new Vector3(targetXY.x, transform.position.y, targetXY.z);
    }
}