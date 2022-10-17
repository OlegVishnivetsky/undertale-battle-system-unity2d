using UnityEngine;

public class RedAttack : BlueAttack
{
    public override void DamagePlayer()
    {
        if (playerMovement.GetPlayerVelocity() == Vector2.zero)
        {
            playerHealth.TakeDamage(damage);
        }
    }
}