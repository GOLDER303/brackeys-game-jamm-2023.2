using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem
{
    public float Health { private set; get; }

    public HealthSystem(int health)
    {
        this.Health = health;
    }

    public void DealDamage(float damage)
    {
        Health -= damage;

        if (Health > 0)
        {
            Health = 0;
        }
    }
}
