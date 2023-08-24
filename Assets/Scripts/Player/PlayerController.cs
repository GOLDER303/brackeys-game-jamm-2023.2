using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private HealthBar healthBar;

    private HealthSystem healthSystem;
    private PlayerInput playerInput;

    private void Awake()
    {
        healthSystem = new HealthSystem(100, healthBar);
        playerInput = GetComponent<PlayerInput>();
    }

    private void HandleDeath()
    {
        playerInput.DeactivateInput();
        gameManager.GameOver();
        // TODO: Death animation
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            float damageAmount = other.gameObject.GetComponent<Enemy>().Damage;
            healthSystem.DealDamage(damageAmount);
        }

        if (healthSystem.health <= 0)
        {
            HandleDeath();
        }
    }

}
