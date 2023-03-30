using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtack : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.7f; // Speed at which the enemy moves towards the player
    [SerializeField] private float attackDistance = 50f; // Distance at which the enemy starts attacking the player
    [SerializeField] private GameObject bulletPrefab; // Prefab for the enemy's bullet game object
    [SerializeField] private float bulletSpeed = 10f; // Speed at which the enemy's bullets move towards the player
  [SerializeField] private float minDelayBeforeStartMoving = 1f; // Minimum delay before the enemy starts moving
    [SerializeField] private float maxDelayBeforeStartMoving = 5f; // Maximum delay before the enemy starts moving
    private float shootDelay = 5f;
    private float delayBeforeStartMoving = 0f;

    private Transform playerShipTransform;

    private void Start()
    {
        playerShipTransform = GameObject.Find("Fighter_03").transform; // Find the player's spaceship game object and store its transform component
        delayBeforeStartMoving = Random.Range(minDelayBeforeStartMoving, maxDelayBeforeStartMoving);
        StartCoroutine(StartMovingAfterDelay());
    }

    private IEnumerator StartMovingAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeStartMoving);
        while (true)
        {
            // Move towards the player's spaceship
            transform.position = Vector3.Lerp(transform.position, playerShipTransform.position, Time.deltaTime * moveSpeed);

            // If within attack distance, start firing bullets
            if (Vector3.Distance(transform.position, playerShipTransform.position) < attackDistance)
            {
                if (shootDelay <= 0)
                {
                    FireBullet();
                    shootDelay = 5f;
                }
                else
                {
                    shootDelay -= Time.deltaTime;
                }
            }

            yield return null;
        }
    }

    private void FireBullet()
    {
        // Instantiate a new bullet game object at the enemy's position
        GameObject newBullet = Instantiate(bulletPrefab, transform.position + new Vector3(0f, 0f, -5f), Quaternion.identity);

        // Calculate the direction in which to fire the bullet
        Vector3 fireDirection = (playerShipTransform.position - transform.position).normalized;

        // Apply a force to the bullet game object to make it move towards the player's spaceship
        newBullet.GetComponent<Rigidbody>().AddForce(fireDirection * bulletSpeed, ForceMode.Impulse);
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