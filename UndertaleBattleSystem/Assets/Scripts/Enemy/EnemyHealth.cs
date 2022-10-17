using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHealth
{
    [SerializeField] private int maxHealth;
    public int CurrentHealth { get; private set; }

    public event Action<int, int> OnHealthChanged;

    private void Start()
    {
        RestoreHealth(maxHealth);
    }

    public void RestoreHealth(int amount)
    {
        if (CurrentHealth + amount > maxHealth)
            return;

        CurrentHealth = amount;
        OnHealthChanged?.Invoke(CurrentHealth, maxHealth);
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        OnHealthChanged?.Invoke(CurrentHealth, maxHealth);
    }
}