using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrelFire : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public Transform bulletSpawnPoint2;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float fireRate = 0.5f;
    private float clickDelay = 0f;

    public CameraRotation CameraRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(clickDelay >= 0)
        {
            clickDelay -= Time.deltaTime;
        }
        if (CameraRotation.turn.x < 0)
        {
            if (Input.GetMouseButtonDown(0) && clickDelay <= 0)
            {
                clickDelay = fireRate;
                var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && clickDelay <= 0)
            {
                clickDelay = fireRate;
                var bullet = Instantiate(bulletPrefab, bulletSpawnPoint2.position, bulletSpawnPoint2.rotation);
                bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint2.forward * bulletSpeed;
            }
        }
        //0.43 11.48 8.93
    }
}
