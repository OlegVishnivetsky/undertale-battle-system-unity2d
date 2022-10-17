using System;
using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealth
{
    [SerializeField] private int maxHealth;

    [SerializeField] private float invulnerabilityTime;
    [SerializeField] private PlayerAnimator playerAnimator;

    public int CurrentHealth { get; private set; }

    private bool canBeDamaged = true;

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
        if (canBeDamaged)
        {
            CurrentHealth -= damage;
            StartCoroutine(EnableInvulnerableMode());
            OnHealthChanged?.Invoke(CurrentHealth, maxHealth);
        }

        if (CurrentHealth <= 0)
        {
            Death();
        }
    }

    private IEnumerator EnableInvulnerableMode()
    {
        canBeDamaged = false;
        playerAnimator.PlayDamagedAnimation();

        yield return new WaitForSeconds(invulnerabilityTime);

        canBeDamaged = true;
        playerAnimator.StopDamagedAnimation();
    }

    private void Death()
    {
        throw new NotImplementedException();
    }
}