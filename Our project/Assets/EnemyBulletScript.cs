using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyBulletScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    private GameObject ground;
    public float force;
    private float timer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        ground = GameObject.FindGameObjectWithTag("Ground");

        if (ground != null)
        {
            Vector3 direction = ground.transform.position - transform.position;
            rb.velocity = direction.normalized * force;
        }

       
    }


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer>10)
        {
            Destroy(gameObject);
        }
    }
}
