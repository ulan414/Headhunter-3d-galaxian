using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackCameraRotation : MonoBehaviour
{
    public Vector2 turn;
    public float sensitivity = .5f;
    public GameObject spaceShip;

    void Update()
    {
        //camera follows space ship
        transform.position = spaceShip.transform.position + new Vector3(0, 2.68f, -10.88f);

        //rotation of the camera
        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        turn.y += Input.GetAxis("Mouse Y") * sensitivity;

        turn.x = Mathf.Clamp(turn.x, -30f, 30f);
        turn.y = Mathf.Clamp(turn.y, -15f, 15f);

        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
    }
}
