using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    [SerializeField] private AudioSource shootingSFX;
    private float timer;
    private Enemy EnemyScript;

    void Start()
    {
        EnemyScript = GetComponent<Enemy>();
    }

    void Update()
    {
        // Check if the enemy is not destroyed
        if (!EnemyScript.destroyed)
        {
            timer += Time.deltaTime;

            // Set the shooting interval (e.g., every 2 seconds)
            float shootingInterval = 2f;

            if (timer > shootingInterval)
            {
                timer = 0;
                shoot();
                shootingSFX.Play();
            }
        }
    }

    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
