using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    private HealthSystem healthSystem;
    private PlayerInput playerInput;

    public PlayerController()
    {
        healthSystem = new HealthSystem(100);
    }

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void HandleDeath()
    {
        playerInput.DeactivateInput();
        gameManager.GameOver();
        // TODO: Death animation
        Destroy(gameObject);
    }

    private void Update()
    {
        Debug.Log(healthSystem.Health);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            float damageAmount = other.gameObject.GetComponent<Enemy>().Damage;
            Debug.Log("Damage: " + damageAmount);
            healthSystem.DealDamage(damageAmount);
        }

        if (healthSystem.Health <= 0)
        {
            HandleDeath();
        }
    }

}
