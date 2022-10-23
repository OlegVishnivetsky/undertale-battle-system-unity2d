using System;

public interface IHealth
{
    public int CurrentHealth { get; }

    public event Action<int, int> OnHealthChanged;

    public void TakeDamage(int damage);

    public void RestoreHealth(int amount);
}