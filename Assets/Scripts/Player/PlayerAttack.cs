using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Bullet bullet;
    public Transform muzzle;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Bullet newBullet = Instantiate(bullet, muzzle.transform.position, Quaternion.identity);

            if (transform.localScale.x > 0)
                newBullet.directionMoving = 1;
            else newBullet.directionMoving = -1;
        }
    }
}
