using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Speed moving")]
    public float speed = 3f;
    public float jumpForce = 90f;
    public Transform pointGroundChecker;
    public LayerMask layerMask;
    
    private Rigidbody2D _rigidbody;
    private float _move = 0;
    private bool _isGrounded = false;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        GetComponent<Animator>().SetBool("Jump", false);
        
        _isGrounded = false;
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(pointGroundChecker.position, 1, layerMask);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].transform.gameObject != gameObject)
            {
                _isGrounded = true;
            }
        }
    }

    private void Update()
    {
        _move = Input.GetAxis("Horizontal");
        GetComponent<Animator>().SetBool("isRunning", _move != 0);
        Move(_move);
        
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded) Jump();
        
        if (_move > 0 && transform.localScale.x < 0) Flip();
        else if (_move < 0 && transform.localScale.x > 0) Flip();
    }

    private void Move(float move)
    {
        _rigidbody.velocity = new Vector2(move * speed, _rigidbody.velocity.y);
    }

    private void Jump()
    {
        _rigidbody.AddForce(new Vector2(0, jumpForce));
        GetComponent<Animator>().SetBool("Jump", true);
    }
    
    public void Flip()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
