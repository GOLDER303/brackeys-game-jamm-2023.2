using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem
{
    public float health { private set; get; }

    private HealthBar healthBar;
    private float initialHealth;

    public HealthSystem(int health, HealthBar healthBar)
    {
        this.health = health;
        initialHealth = health;

        this.healthBar = healthBar;
    }

    public void DealDamage(float damage)
    {
        health -= damage;

        if (health < 0)
        {
            health = 0;
        }

        healthBar.SetSize(health / initialHealth);
    }
}
