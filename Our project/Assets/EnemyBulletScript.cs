using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBulletScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    private GameObject ground;
    public float force;
    private float timer;
    private Animator anim;
    private bool destroyed;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        ground = GameObject.FindGameObjectWithTag("Ground");

        if (ground != null && !destroyed)
        {
            Vector3 direction = ground.transform.position - transform.position;
            rb.velocity = direction.normalized * force;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    public void SetDestroyed(bool value)
    {
        destroyed = value;
    }

    void Update()
    {
        if(!destroyed)
        {
        timer += Time.deltaTime;

        if (timer > 5)
        {
            Destroy(gameObject);
        }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Health playerHealth = other.gameObject.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.HandleAnotherTrapCollision();
                Destroy(gameObject);
            }
        }
        else if (other.gameObject.CompareTag("Ground"))
        {
            // Destroy the bullet when it collides with an object tagged as "Ground"
            Destroy(gameObject);
        }
    }
}

