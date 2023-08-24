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
    private Dictionary<string, int> resourcesHeld = new();

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Resource"))
        {
            string resourceName = other.GetComponent<Resource>().ResourceName;

            if (!resourcesHeld.ContainsKey(resourceName))
            {
                resourcesHeld.Add(resourceName, 0);
            }

            resourcesHeld[resourceName]++;

            Destroy(other.gameObject);
        }
    }
}
