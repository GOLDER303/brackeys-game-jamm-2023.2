using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float damage;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private float angleoffset = 0f;
    [SerializeField] private bool canMove = true;

    public float Damage => damage;
    public GameObject targetGameObject { set; private get; }

    private HealthSystem healthSystem;

    private void Awake()
    {
        healthSystem = new HealthSystem(100, healthBar);
    }

    public void HandleDeath()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        RotateTowardsTarget();
        if (canMove)
        {
            MoveTowardsTarget();
        }
    }

    public void DealDamage(float damageAmount)
    {
        healthSystem.DealDamage(damageAmount);

        if (healthSystem.health == 0)
        {
            HandleDeath();
        }
    }

    private void RotateTowardsTarget()
    {
        Vector2 direction = targetGameObject.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + angleoffset));
    }

    private void MoveTowardsTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetGameObject.transform.position, moveSpeed * Time.deltaTime);
    }

    public void EnableMovement()
    {
        canMove = true;
    }

    public void DisableMovement()
    {
        canMove = false;
    }
}
