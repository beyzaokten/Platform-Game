using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] float distance;
    [SerializeField] float speed;
    private bool isMovingLeft;
    private float leftEdge;
    private float rightEdge;

    private void Awake()
    {
        leftEdge = transform.position.x - distance;
        rightEdge = transform.position.x + distance;
    }

    private void Update()
    {
        if(isMovingLeft)
        {
            if(transform.position.x > leftEdge)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
                transform.localScale = new Vector3(5f, 5f, 5f);

            }
            else 
            {
                isMovingLeft = false; 
            }
        }
        else
        {
            if (transform.position.x < rightEdge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
                transform.localScale = new Vector3(-5f, 5f, 5f);

            }
            else
            {
                isMovingLeft = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
