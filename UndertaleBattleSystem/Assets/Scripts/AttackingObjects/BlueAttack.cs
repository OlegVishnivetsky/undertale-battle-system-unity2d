using UnityEngine;

public class BlueAttack : AttackingObject
{
    protected PlayerMovement playerMovement;
    protected PlayerHealth playerHealth;

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerMovement>(out PlayerMovement playerMovement) &&
            other.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
        {
            this.playerMovement = playerMovement;
            this.playerHealth = playerHealth;
        }
        else
        {
            this.playerMovement = null;
            this.playerHealth = null;
        }
    }

    public override void OnTriggerStay2D(Collider2D other)
    {
        DamagePlayer();
    }

    public virtual void DamagePlayer()
    {
        if (playerMovement.GetPlayerVelocity() != Vector2.zero)
        {
            playerHealth.TakeDamage(damage);
        }
    }
}