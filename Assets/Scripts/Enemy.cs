using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float damage;
    [SerializeField] private HealthBar healthBar;

    public float Damage => damage;
    public GameObject targetGameObject { set; private get; }

    private HealthSystem healthSystem;

    private void Start()
    {
        healthSystem = new HealthSystem(100, healthBar);
    }

    public void HandleDeath()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetGameObject.transform.position, moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Weapon"))
        {
            float damageAmount = other.GetComponent<WeaponBehaviour>().Damage;
            healthSystem.DealDamage(damageAmount);
        }

        if (healthSystem.Health == 0)
        {
            HandleDeath();
        }
    }
}
