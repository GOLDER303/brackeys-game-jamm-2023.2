using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static Action<Resource> OnResourceCollected;

    [SerializeField] private GameManager gameManager;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private GameObject upgradeMenuCanvas;

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

    private void OnOpenUpgradeMenu()
    {
        if (upgradeMenuCanvas.activeSelf)
        {
            upgradeMenuCanvas.SetActive(false);
        }
        else
        {
            upgradeMenuCanvas.SetActive(true);
        }
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
            Resource resource = other.GetComponent<Resource>();
            string resourceName = resource.name;

            if (!resourcesHeld.ContainsKey(resourceName))
            {
                resourcesHeld.Add(resourceName, 0);
            }

            resourcesHeld[resourceName]++;

            OnResourceCollected?.Invoke(resource);

            Destroy(other.gameObject);
        }
    }
}
