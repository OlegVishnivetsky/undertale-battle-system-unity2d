using UnityEngine;

public class WhiteAttack : AttackingObject
{
    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
        {
            playerHealth.TakeDamage(damage);
        }
    }
}