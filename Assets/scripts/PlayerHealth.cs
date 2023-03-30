using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public EnemyKilled EnemyKilled;
    public EnemySpawner EnemySpawner;


    private void Start()
    {
        currentHealth = maxHealth;
    }
    void Update()
    {
        foreach(Image img in hearts)
        {
            img.sprite = emptyHeart;
        }
        for(int i = 0; i < currentHealth; i++)
        {
            hearts[i].sprite = fullHeart;
        }
    }

    public void TakeDamage()
    {
        currentHealth--;

        if (currentHealth <= 0)
        {
            Debug.Log("Dead");
            EnemyKilled.Failed();
            Clear();
        }
    }
    public void Clear()
    {
        //disable camera rotation and make cursor visible
        Camera.main.GetComponent<CameraRotation>().enabled = false;
        GameObject backgroundCamera = GameObject.Find("BackgroundCamera");
        backgroundCamera.GetComponent<BackCameraRotation>().enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //destroy all enemies and disable spawning
        EnemySpawner.enabled = false;
        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag("ENEMY");
        foreach (GameObject objectToDestroy in objectsToDestroy)
        {
            Destroy(objectToDestroy);
        }
        //destroy bullets
        GameObject[] objectsToDestroy2 = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject objectToDestroy2 in objectsToDestroy2)
        {
            Destroy(objectToDestroy2);
        }
        MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;
        MoveForward MoveForward = gameObject.GetComponent<MoveForward>();
        MoveForward.enabled = false;
        TurrelFire TurrelFire = gameObject.GetComponent<TurrelFire>();
        TurrelFire.enabled = false;

        GameObject childObject = transform.Find("Turet01").gameObject;
        childObject.SetActive(false);
        GameObject childObject2 = transform.Find("Turet01 (1)").gameObject;
        childObject2.SetActive(false);
    }
}