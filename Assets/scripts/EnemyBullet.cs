using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float lifeTime = 2f; // Amount of time the bullet will exist before being destroyed

    private void Start()
    {
        // Destroy the bullet game object after the specified lifetime
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // If the bullet collides with the player's spaceship, damage it and destroy the bullet
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("player");
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage();
            }
            Destroy(gameObject);
        }
    }
}
