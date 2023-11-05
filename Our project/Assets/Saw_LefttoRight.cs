using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw_Horizontal : MonoBehaviour
{
    [SerializeField] private float movementDistance;
    [SerializeField] private float speed;
    private bool movingRight;
    private float rightEdge;
    private float leftEdge;

    private void Awake()
    {
        leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;
    }

    private void Update()
    {
        if (movingRight)
        {
            if (transform.position.x < rightEdge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
                movingRight = false;
        }
        else
        {
            if (transform.position.x > leftEdge)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
                movingRight = true;
        }
    }
}