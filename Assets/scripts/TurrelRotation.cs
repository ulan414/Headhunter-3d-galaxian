using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrelRotation : MonoBehaviour
{
    public LayerMask ENEMY;
    public Transform ShotPoint;
    float distance = 100f;
    Vector3 endpoint = new Vector3(0, 0, 0);

    void Start()
    {

    }

    void Update()
    {
        RaycastHit hit; 
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, distance + 40f, ENEMY))
            endpoint = hit.point;
        else
            endpoint = Camera.main.transform.position + Camera.main.transform.forward.normalized * distance; //rotate turrel where crosshair aimed
        //endpoint = new Vector3(0, 8.06999969f, -10.8800001f) + Camera.main.transform.forward.normalized * distance; //rotate turrel where crosshair aimed
        transform.LookAt(endpoint);
        ShotPoint.transform.LookAt(endpoint);
        //Debug.DrawRay(ShotPoint.transform.position, endpoint, Color.green);
        //Debug.Log(endpoint);
        //-0.05 11.04 7.63
    }
}
