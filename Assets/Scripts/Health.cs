using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    protected int _health = 3;

    public void Death()
    {
        print("Death of object: " + gameObject.name);
        Destroy(gameObject);
    }

    public virtual void DecreaseHealth()
    {
        _health -= 1;
        
        if (_health < 1) Death();
    }

    public void IncreaseHealth()
    {
        _health += 1;
    }

    public int GetHealth()
    {
        return _health;
    }
}
