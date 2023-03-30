using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3f;
    EnemyKilled EnemyKilled;
    // Start is called before the first frame update
    void Awake()
    {
        Destroy(gameObject, life);
        GameObject myGameObject = GameObject.Find("EventSystem");
        EnemyKilled = myGameObject.GetComponent<EnemyKilled>();
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ENEMY")
        {
            EnemyKilled.Count();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
