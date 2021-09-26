using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Bullet bullet;
    public Transform muzzle;

    private Transform _player;
    private bool _isAngry = false;

    private void Update()
    {
        if (!_isAngry) return;
        if (_player.position.x > transform.position.x) FlipRight(); else FlipLeft();
    }

    public void SetAngry(Transform player)
    {
        _player = player;
        _isAngry = true;
        StartCoroutine(AttackDelay());
    }

    public void Attack()
    {
        Bullet newBullet = Instantiate(bullet, muzzle.position, Quaternion.identity);

        if (transform.localScale.x > 0)
            newBullet.directionMoving = 1;
        else newBullet.directionMoving = -1;
    }

    private IEnumerator AttackDelay()
    {
        Attack();
        yield return new WaitForSeconds(2);
        StartCoroutine(AttackDelay());
    }
    
    public void FlipLeft()
    {
        transform.localScale = new Vector3(Math.Abs(transform.localScale.x) * -1, transform.localScale.y, transform.localScale.z);
    }
    
    public void FlipRight()
    {
        transform.localScale = new Vector3(Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }
}
