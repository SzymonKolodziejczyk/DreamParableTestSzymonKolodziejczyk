using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    public event Action<int> OnHealthChanged; // Event to notify health changes

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Check if the enemy is dead
        if (currentHealth <= 0)
        {
            Die();
        }

        // Notify the UI about the health change
        OnHealthChanged?.Invoke(currentHealth);
    }

    private void Die()
    {
        // Destroy the enemy object or perform any other actions
        Destroy(gameObject);
    }
}