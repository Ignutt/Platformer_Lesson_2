using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float directionMoving = 1;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = -Vector2.left * directionMoving * speed; 
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.GetComponent<Health>()) 
            other.transform.GetComponent<Health>().DecreaseHealth();
        
        Destroy(gameObject);
    }
}
